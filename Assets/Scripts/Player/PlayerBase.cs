using UnityEngine;

namespace Player
{
    public abstract class PlayerBase: MonoBehaviour
    {
        protected static readonly int IsMovingParam = Animator.StringToHash("isMoving");
        protected static readonly int IsGroundedParam = Animator.StringToHash("isMoving");

        protected static bool IsGrounded = false;
    }
}