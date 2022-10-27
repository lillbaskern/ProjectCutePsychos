using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    #region WalkingVariables

    [Header("Horizontal Movement")]

    public float moveSpeed = 5f;

    public float activeMoveSpeed;

    public float acceleration = 70;
    public float deAcceleration = 50;
    public float currentDirection;

    public float topSpeed;
    #endregion

    #region DashVariables

    [Header("Dashing")]

    [SerializeField] private bool _canDash;

    public float dashSpeed;

    public float dashLength = .5f;

    public float dashCoolDown = 1f;

    private float dashCounter;

    private float dashCoolDownCounter;

    [SerializeField] private bool isDashing;
    #endregion

    #region GroundCheckVariables
    [Header("Ground Check")]

    //ground

    [SerializeField] private bool _isGrounded;
    public Transform groundCheck;

    private float _checkGroundRadius;

    public LayerMask whatIsGround;

    #endregion

    #region JumpVariables
    [Header("Jump")]

    //MultiJump
    [SerializeField] private bool _canJump;

    public float jumpForce;

    public float doubleJumpForce;

    [SerializeField] private bool _canDoubleJump;

    [SerializeField] private int _extraJumps;

    #endregion

    #region WallJumpVariables

    [Header("Wall Check")]

    //wall

    [SerializeField] public static bool canWallSlide;

    [SerializeField] public static bool canWallJump;

    [SerializeField] private bool _isTouchingFront;

    public Transform frontcheck;

    [SerializeField] private bool _wallSliding;

    [SerializeField] private float _checkWallRadius;

    public float wallSlidingSpeed;

    public LayerMask whatIsWall;

    #endregion


    private float _moveInputX;

    // Start is called before the first frame update
    void Start()
    {
        topSpeed = moveSpeed * 2;
        dashSpeed = moveSpeed * 4;
        activeMoveSpeed = moveSpeed;
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        #region _isGrounded
        //check if the player is grounded and reset available jumps if the player is grounded

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.35f, whatIsGround);

        if (_isGrounded == true && _canDoubleJump == true)
        {
            _extraJumps = 1;
        }
       
        #endregion

        #region Horizontal Walk
        //Move the player
        
         _rb2d.velocity = new Vector2(_moveInputX * activeMoveSpeed, _rb2d.velocity.y);
            
        if (_moveInputX != 0)
        {
            CalculateSpeed();
        }

        #endregion

        #region Dashing
        // If both the dash duration counter and the dash Cooldown is 0 or less the player can dash
        if (dashCoolDownCounter <= 0 && dashCounter <= 0)
        {
            _canDash = true;
        }
        //Dash duration countdown and reset currentSpeed to moveSpeed
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = topSpeed;
                dashCoolDownCounter = dashCoolDown;
                _canDash = false;
            }
        }
        //Start the cooldown between dashes
        if (dashCoolDownCounter > 0)
        {
            dashCoolDownCounter -= Time.deltaTime;
        }
        #endregion

        #region WallChcek
        //Wall
        _isTouchingFront = Physics2D.OverlapCircle(frontcheck.position, _checkWallRadius, whatIsWall);

        if (_isTouchingFront == true && _isGrounded == false && _moveInputX != 0)
        {
            _wallSliding = true;

        }
        else
        {
            _wallSliding = false;
        }
        if (_wallSliding)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, Mathf.Clamp(_rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        #endregion
    }

    //Calculate speed for acceleration
    private void CalculateSpeed()
    {
        if(Mathf.Abs(_moveInputX) > 0)
        {
            activeMoveSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            activeMoveSpeed -= deAcceleration * Time.deltaTime;
        }

        activeMoveSpeed = Mathf.Clamp(activeMoveSpeed, 0, topSpeed);
    }


    #region CallMoveFuntion
    //Call move function
    public void Move(InputAction.CallbackContext context)
    {
        _moveInputX = context.ReadValue<Vector2>().x;
    }
    #endregion

    #region CallJumpFunction
    //Call Jump Function
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_extraJumps >= 0 && _isGrounded == true)
            {
                _rb2d.velocity = Vector2.up * jumpForce;
                Debug.Log("jump Pressed");
            }

            if (_extraJumps > 0 && _isGrounded == false)
            {
                _rb2d.velocity = Vector2.up * doubleJumpForce;
                _extraJumps--;
                Debug.Log("jump Pressed while in air");
            }
        }
    }
    #endregion

    #region CallDashFunction
    //Call Dash funtion
    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && _canDash)
        {
            activeMoveSpeed = dashSpeed;
            dashCounter = dashLength;
        }
    }
    #endregion

    #region DrawGizmo
    //draw outline for groundcheck and wallcheck
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, _checkGroundRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(frontcheck.position, _checkWallRadius);
    }
    #endregion
}
