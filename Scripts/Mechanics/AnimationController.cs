using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// AnimationController integrates physics and animation. It is generally used for simple enemy animation.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
    public class AnimationController : KinematicObject
    {
        /// <summary>
        /// Velocidad horizontal máxima.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Velocidad máxima del salto.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        /// <summary>
        /// Usado para indicar la dirección deseada del camino.
        /// </summary>
        public Vector2 move;

        /// <summary>
        /// Setear a true para iniciar un salto.
        /// </summary>
        public bool jump;

        /// <summary>
        /// Setear a true para indicar la velocidad del salto a 0.
        /// </summary>
        public bool stopJump;

        SpriteRenderer spriteRenderer;
        Animator animator;
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        protected virtual void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        //Calcular velocidad
        protected override void ComputeVelocity()
        {

            if (move.x > 0.01f)
                spriteRenderer.flipX = true;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = false;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }
    }
}