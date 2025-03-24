using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : PlayerBase
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpForce = 2f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckRadius = 0.2f;

        private bool _isJumpPressed;
        private float _movementInput;
        private Rigidbody2D _playerRb;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody2D>();

            if (groundCheck == null)
            {
                var gc = new GameObject("GroundCheck");
                gc.transform.SetParent(transform);
                gc.transform.localPosition = new Vector3(0f, -1.36f, 0f);
                groundCheck = gc.transform;
            }
        }

        private void Update()
        {
            _movementInput = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump") && IsGrounded) _isJumpPressed = true;
        }

        private void FixedUpdate()
        {
            CheckIsGrounded();
            _playerRb.linearVelocity = new Vector2(_movementInput * moveSpeed, _playerRb.linearVelocity.y);

            if (_isJumpPressed)
            {
                _playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                _isJumpPressed = false;
            }

            HandleFlip();
        }

        private void OnDrawGizmosSelected()
        {
            if (groundCheck == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }

        private void HandleFlip()
        {
            transform.localScale = _playerRb.linearVelocity.x switch
            {
                > 0 => new Vector3(1, 1, 1),
                < 0 => new Vector3(-1, 1, 1),
                _ => transform.localScale
            };
        }

        private void CheckIsGrounded()
        {
            IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }
    }
}