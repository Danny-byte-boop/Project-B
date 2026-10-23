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
    public LayerMask groundLayer; // Assign your Ground Layer here in Inspector

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // --- CHECK IF GROUNDED ---
        // This draws a tiny line under DIRK. If it hits the "Ground" layer, he's grounded.
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.green); // Visual debug

        // --- JUMP LOGIC ---
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

        // --- WALKING LOGIC ---
        float horizontal = 0f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            horizontal = -1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            horizontal = 1f;

        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        // Use 'isGrounded' bool from raycast for animation
        bool isWalking = Mathf.Abs(horizontal) > 0.1f && isGrounded;
        animator.SetBool("Walking", isWalking);

        // 2. Flip the character based on direction
        if (horizontal > 0)
        {
            // Facing Right: Reset scale to normal
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            // Facing Left: Flip X to -1
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
       

