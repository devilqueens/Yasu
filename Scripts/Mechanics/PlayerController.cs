using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        //colisión ataque Yasu
        public Transform attackPoint;
        public float attackRange = 0.5f;
        public LayerMask enemyLayers;
        //public Rigidbody2D RGB;
        //public float jumpForce = 50f;

        //variable del tiempo para que no pueda atacar todo el rato:
        public float attackRate = 2f;
        float nextAttackTime = 0f;

        bool IsCrouched;
        bool IsAttacking;
        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        public Animator animator;  //animator
                //daño al enemigo
        public int attackDamage = 40;

        public Animator animEn1;
        public Animator animEn2;
        public Animator animEn3;
        public Animator animEn4;
        public Animator animEn5;
        public Animator animEn6;

        public GameObject rocas;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            
        }

        protected override void Update()
        {
            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    IsAttacking = true;
                    Attack();
                    nextAttackTime = Time.time + 2f / attackRate;
                }
            }
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetKeyDown(KeyCode.UpArrow))
                    jumpState = JumpState.PrepareToJump;
             
            }
            else
            {
                move.x = 0;
            }

            UpdateJumpState();
            base.Update();
            animator.SetBool("crouched", IsCrouched);
            animator.SetBool("attacking", IsAttacking);


            //Condicional si Yasu se agacha
            if (Input.GetKey(KeyCode.DownArrow))
            {
                IsCrouched = true;
                //move.x = 0;
                //move.y = 0;
            }
            else
            {
                IsCrouched = false;
            }

            //Condicional si Yasu Ataca
           
            if (Input.GetKeyUp(KeyCode.Z))
            {

                IsAttacking = false;
            }


        }
        void ocultarRocas()
        {
            Debug.Log("rocas fuera");
            rocas.SetActive(false); 
        }
        void Attack()
        {

            //hacer daño enemigos
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            


            foreach (Collider2D _collider in hitEnemies)
            {
                Debug.Log("We hit " + _collider.name);
                //llamamos al script del boss controller para acceder al takedamage.
                //_collider.GetComponent<BossController>().TakeDamage(20);
                if (_collider.name == "Enemy1")
                {
                    animEn1.SetTrigger("death");
                }
                else if (_collider.name == "Enemy2")
                {
                    animEn2.SetTrigger("death");
                }
                else if (_collider.name == "Enemy3")
                {
                    animEn3.SetTrigger("death");
                }
                else if (_collider.name == "Enemy4")
                {
                    animEn4.SetTrigger("death");
                }
                else if (_collider.name == "Enemy5")
                {
                    animEn5.SetTrigger("death");
                }
                else if (_collider.name == "Enemy6")
                {
                    animEn6.SetTrigger("isDead");
                    
                }
                ocultarRocas();
                _collider.enabled = false;
            }
        }

        void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
            

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}