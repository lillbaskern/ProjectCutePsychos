using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb2d;

    #region WalkingVariables

    [Header("Horizontal Movement")]

<<<<<<< Updated upstream
=======
    [Header("Horizontal Movement")]
>>>>>>> Stashed changes
    public float moveSpeed = 5f;

    public float activeMoveSpeed;

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
<<<<<<< Updated upstream

    private float _checkGroundRadius;

    public LayerMask whatIsGround;
=======
    public LayerMask whatIsGroundMask;
    public float checkGroundRadius;
>>>>>>> Stashed changes

    #endregion

    #region JumpVariables
    [Header("Jump")]

    //MultiJump

    public float jumpForce;

    public bool canDoubleJump;

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
        dashSpeed = moveSpeed * 4;
        activeMoveSpeed = moveSpeed;
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        #region _isGrounded
        //check if the player is grounded and reset available jumps if the player is grounded
        if (_isGrounded == true && canDoubleJump == true)
        {
<<<<<<< Updated upstream
            _extraJumps = 1;
        }

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.35f, whatIsGround);
        #endregion

        #region Horizontal Walk
        //Move the player
        _rb2d.velocity = new Vector2(_moveInputX * activeMoveSpeed, _rb2d.velocity.y);
        #endregion
=======
            availableJumps = maxjumps;
            canJump = true;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 1f, whatIsGroundMask);

        //Apply Motion Vectors.
        rb.velocity = new Vector2(inputX * currentSpeed, rb.velocity.y);
>>>>>>> Stashed changes

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
                activeMoveSpeed = moveSpeed;
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

<<<<<<< Updated upstream
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
=======
        if (isDashing)
        {

        }

>>>>>>> Stashed changes
    }

    #region CallMoveFuntion
    //Call move function
    public void Move(InputAction.CallbackContext context)
    {
<<<<<<< Updated upstream
        _moveInputX = context.ReadValue<Vector2>().x;
=======
        Debug.Log(context);
        inputX = context.ReadValue<Vector2>().x;
>>>>>>> Stashed changes
    }
    #endregion

    #region CallJumpFunction
    //Call Jump Function
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
<<<<<<< Updated upstream
            if (_extraJumps >= 0 && _isGrounded == true)
            {
                _rb2d.velocity = Vector2.up * jumpForce;
            }
            if (_extraJumps > 0 && _isGrounded == false)
            {
                _rb2d.velocity = Vector2.up * jumpForce;
                _extraJumps--;
=======
            if (availableJumps <= -1)
            {
                canJump = false;
                return;//keep code from pogressing further if available jumps is lower than 0
            }
            if (availableJumps >= 0)//this if statement could be removed but it might be best to leave it for readability (elias)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                availableJumps--;
>>>>>>> Stashed changes
            }
        }
    }
    #endregion

    #region CallDashFunction
    //Call Dash funtion
    public void Dash(InputAction.CallbackContext context)
    {
<<<<<<< Updated upstream
        if (context.performed && _canDash)
=======
        if (context.performed && canDash)
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        Gizmos.DrawWireSphere(groundCheck.position, _checkGroundRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(frontcheck.position, _checkWallRadius);
=======
        Gizmos.DrawWireSphere(groundCheck.position, checkGroundRadius);//if the Player is not set up correctly an error will redirect to here
>>>>>>> Stashed changes
    }
    #endregion
}
