using System.Collections;
using UnityEngine;
[RequireComponent(typeof(ExperimentalController2D))]
[RequireComponent(typeof(ExperimentalInputController))]
public class ExperimentalPlayer : MonoBehaviour
{
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    [SerializeField] float _accelerationTimeAirborne = .34f;
    [SerializeField] float _accelerationTimeGrounded = .2f;
    [SerializeField] float _moveSpeed = 9;

    float _baseMoveSpeed;


    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector2 velocity; //Maximum targetted velocity. 
    float velocityXSmoothing;

    ExperimentalController2D controller;
    ExperimentalInputController input;
    Vector2 directionalInput;
    bool wallSliding;
    int wallDirX;
    public int dirX;

    int availableDoubleJumps;//current amount of available double jumps

    public float dashSpeedX;//x part of the dash vector
    public float dashSpeedY;//y part of the resulting velocity vector from dashing
    public float dashCooldown;
    float nextDash = 0;//when time.time reaches this value the player can dash again
    public int maxDoubleJumps = 1;//the max amount of potentially available double jumps. availabledoublejumps resets to this when player is grounded 
    [SerializeField] bool dontPollInputs;

    private Vector2 spawnPoint; //where the player will respawn at. Is set to the players starting position in Awake(), and to any vector2 in SetSpawnPoint()

    private SpriteRenderer _playerSprite;

    void Awake()
    {
        _baseMoveSpeed = _moveSpeed;
        controller = GetComponent<ExperimentalController2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
        input = GetComponent<ExperimentalInputController>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        spawnPoint = this.transform.position;
    }

    void Update()
    {
        int lastDirX = dirX;
        CalculateVelocity();
        HandleWallSliding();

        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0;
            }
        }
        if (controller.collisions.below)
        {
            availableDoubleJumps = maxDoubleJumps;
        }
        if (wallSliding)
        {
            _playerSprite.flipX = controller.collisions.left ? false : true; //set sprite orientation to face opposite of the wall youre sliding
            dirX = controller.collisions.left ? 1 : -1; //if there are collisions on the left of the player set dirx to +1 (right), if not set it to -1 (left)
            return;
        }
        if (velocity.x > -0.1f && velocity.x < 0.1f)//is this small enough
            dirX = lastDirX;
        dirX = (int)Mathf.Sign(velocity.x);
        _playerSprite.flipX = dirX < 0;
    }

    public void SetDirectionalInput(Vector2 input)
    {
        if (dontPollInputs) return;
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        Debug.Log($"Wallsliding: {wallSliding}");
        if (wallSliding)
        {
            if (wallDirX == directionalInput.x)
            {
                velocity.x = -wallDirX * wallJumpClimb.x;
                velocity.y = wallJumpClimb.y;
            }
            else if (directionalInput.x == 0)
            {
                velocity.x = -wallDirX * wallJumpOff.x;
                velocity.y = wallJumpOff.y;
            }
            else
            {
                velocity.x = -wallDirX * wallLeap.x;
                velocity.y = wallLeap.y;
            }
            return;
        }
        if (controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                if (directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
                {
                    velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
                    velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
                }
            }
            else
            {
                velocity.y = maxJumpVelocity;
            }
        }
        if (!controller.collisions.below && !controller.collisions.above && availableDoubleJumps > 0)
        {
            velocity.y = maxJumpVelocity;
            availableDoubleJumps--;
        }
    }

    public void OnJumpInputUp()
    {

        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }


    void HandleWallSliding()
    {
        wallSliding = false;
        if(!controller.collisions.wallSlidingAllowed) 
            return; // guard clause

        wallDirX = (controller.collisions.left) ? -1 : 1;
        
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (directionalInput.x != wallDirX && directionalInput.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }

        }

    }

    public IEnumerator Boost(float speedMultiplier, float duration)
    {
        int directionX = (int)Mathf.Sign(velocity.x);
        SetDirectionalInput(new Vector2(directionX, 0f));
        dontPollInputs = true;
        _moveSpeed = _moveSpeed * speedMultiplier;
        float dontPollFor = duration * 0.25f;
        yield return new WaitForSeconds(dontPollFor);
        dontPollInputs = false;
        yield return new WaitForSeconds(duration - dontPollFor);
        input.PollDirection();//polldirection checks player input independently from callbacks
        ResetMoveSpeed();
    }

    //<summary>
    //simple method which sets the dynamic moveSpeed variable to baseMoveSpeed, which is set in start
    public void ResetMoveSpeed()
    {
        _moveSpeed = _baseMoveSpeed;
    }

    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * _moveSpeed;
        bool InputtingOppositeDirections = targetVelocityX < 0f && velocity.x > 0f || targetVelocityX > 0f && velocity.x < 0f;
        if (Mathf.Abs(targetVelocityX) < Mathf.Abs(velocity.x) && !InputtingOppositeDirections)//if we're moving faster than the target speed and not inputting the opposite direction
        {
            targetVelocityX = velocity.x;
            targetVelocityX *= 0.7f;
        }
        if (controller.collisions.below && velocity.x > -(_moveSpeed / 2) && velocity.x < _moveSpeed / 2 && directionalInput.y < -0.75)
        {
            targetVelocityX  = velocity.x;
            targetVelocityX *= 0.1f;
        }
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? _accelerationTimeGrounded : _accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
    }
    public void Dash()
    {
        //guard clauses
        if (wallSliding) return;
        if (Time.time < nextDash) return;
        //Actually doing things
        nextDash = Time.time + dashCooldown;
        velocity.x += dashSpeedX * dirX;
        velocity.y = 3f;
    }

    public void SetSpawnPos(Vector2 newPos)
    {
        if (spawnPoint != newPos)
            spawnPoint = newPos;
    }
    public IEnumerator Respawn(float delay)
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);
        this.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        velocity = Vector2.zero;
        ResetMoveSpeed();//to fix some bugs related to dying during a speed boost we reset movespeed here
    }
    private void OnEnable()
    {
        this.transform.position = spawnPoint;
        velocity = Vector2.zero;
        input.PollDirection();
    }
}
