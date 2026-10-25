using UnityEngine;
using UnityEngine.InputSystem;
public class Jump : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    public float jumpForce = 10f;
    public float moveSpeed = 5f;

    // How far down to "feel" the ground
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer; 
    //Start() gets the animation for DIRK made from Aseprite
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // This draws a tiny line under DIRK. If it hits the "Ground" layer, he's grounded.
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.green); // Visual debug

        // This is for the jump logic where it enables the player to jump when they interact with the spacebar
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

        // This method allows DIRK to be able to move left to right when the player presses A(left) or D(right)
        float horizontal = 0f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            horizontal = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            horizontal = 1f;

        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        // Using 'isGrounded' tool for raycasting on DIRK
        bool isWalking = Mathf.Abs(horizontal) > 0.1f && isGrounded;
        animator.SetBool("Walking", isWalking);

        // This flips DIRK based on the direction that he's facing
        if (horizontal > 0)
        {
            // If DIRK is facing right it sets it back to normal
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            // If DIRK is facing left; it sets X to -1
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
       

