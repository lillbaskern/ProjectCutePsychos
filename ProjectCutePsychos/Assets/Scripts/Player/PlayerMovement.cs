using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    [Header ("Horizontal Movement")]
    public float moveSpeed = 5f;
    public float currentSpeed;
    public float topSpeed;

    [Header("Dashing")]
    public bool canDash;
    public float dashSpeed;
    public float dashLength = .5f, dashCoolDown = 1f;
    private float dashCounter;
    private float dashCoolDownCounter;
    [SerializeField] private bool isDashing;


    [Header("Check if grounded")]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkGroundRadius;

    [Header("Jumping")]
    public float jumpForce;
    public float maxjumps;
    public float availableJumps;
    public bool canJump;


    private float inputX;


    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = moveSpeed;
        availableJumps = maxjumps;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //check if the player is grounded and reset available jumps if the player is grounded
        if (isGrounded == true)
        {
            availableJumps = maxjumps;
            canJump = true;
        }   

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 1f, whatIsGround);

        //Move the player
        rb.velocity = new Vector2(inputX * currentSpeed, rb.velocity.y);

        // If both the dash duration counter and the dash Cooldown is 0 or less the player can dash
        if (dashCoolDownCounter <= 0 && dashCounter <= 0)
        {
            canDash = true;
            isDashing = true;
        }

        //Dash duration countdown and reset currentSpeed to moveSpeed
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                currentSpeed = moveSpeed;
                dashCoolDownCounter = dashCoolDown;
                canDash = false;
                isDashing = false;
            }
        }
        //Start the cooldown between dashes
        if (dashCoolDownCounter > 0)
        {
            dashCoolDownCounter -= Time.deltaTime;
        }

        if (isDashing == true)
        {
            
        }
    }

    //Call move function
    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    //Call Jump Function
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && canJump)
        {
            if (availableJumps >= 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                availableJumps --;
            }

            if(availableJumps <= -1)
            {
                canJump = false;
            }
        }
    }

    //Call Dash funtion
    public void Dash(InputAction.CallbackContext context)
    {
        if(context.performed && canDash)
        {
            currentSpeed = dashSpeed;
            dashCounter = dashLength;
        }
    }

    //draw outline for groundcheck and wallcheck
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, checkGroundRadius);
    }
}
