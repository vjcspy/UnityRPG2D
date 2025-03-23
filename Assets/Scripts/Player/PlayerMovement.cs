using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private float movementInput;
    private bool isJumpPressed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Nếu chưa gán groundCheck trong Inspector thì tạo tự động
        if (groundCheck == null)
        {
            GameObject gc = new GameObject("GroundCheck");
            gc.transform.SetParent(transform);
            gc.transform.localPosition = new Vector3(0f, -1.36f, 0f); // chỉnh sao cho đúng vị trí chân
            groundCheck = gc.transform;
        }
    }

    void Update()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        // Di chuyển ngang
        rb.linearVelocity = new Vector2(movementInput * moveSpeed, rb.linearVelocity.y);

        // Nhảy
        if (isJumpPressed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumpPressed = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}