using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 2f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius = 0.2f;
        private bool isJumpPressed;
        private float movementInput;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();

            // Nếu chưa gán groundCheck trong Inspector thì tạo tự động
            if (groundCheck == null)
            {
                var gc = new GameObject("GroundCheck");
                gc.transform.SetParent(transform);
                gc.transform.localPosition = new Vector3(0f, -1.36f, 0f); // chỉnh sao cho đúng vị trí chân
                groundCheck = gc.transform;
            }
        }

        private void Update()
        {
            movementInput = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump") && IsGrounded()) isJumpPressed = true;
        }

        private void FixedUpdate()
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

        private void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
    }
}