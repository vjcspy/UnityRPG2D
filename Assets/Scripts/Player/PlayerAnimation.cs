using UnityEngine;

namespace Player
{
    public class PlayerAnimation : PlayerBase
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D playerRb;

        private void Start()
        {
            playerRb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            animator.SetBool(IsMovingParam, IsMoving);
            animator.SetBool(IsGroundedParam, IsGrounded);
            animator.SetFloat(YVelocityParam, playerRb.linearVelocity.y);
        }
    }
}