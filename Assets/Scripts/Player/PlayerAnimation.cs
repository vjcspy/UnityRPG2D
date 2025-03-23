using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("isMoving");

        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D playerRb;

        private void Start()
        {
            playerRb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var isMoving = Mathf.Abs(playerRb.linearVelocity.x) != 0.0f;
            animator.SetBool(IsMoving, isMoving);
        }
    }
}