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
            var isMoving = Mathf.Abs(playerRb.linearVelocity.x) != 0.0f;
            animator.SetBool(IsMovingParam, isMoving);
        }
    }
}