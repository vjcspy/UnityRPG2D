﻿using UnityEngine;

namespace Player
{
    public abstract class PlayerBase: MonoBehaviour
    {
        protected static readonly int IsMovingParam = Animator.StringToHash("isMoving");
        protected static readonly int IsGroundedParam = Animator.StringToHash("isGrounded");
        protected static readonly int YVelocityParam = Animator.StringToHash("yVelocity");

        protected static bool IsGrounded = false;
        protected static bool IsMoving = false;
    }
}