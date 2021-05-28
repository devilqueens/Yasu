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
    /// Clase control de jugador.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        //Declaración variables audio
        public AudioClip jumpAudio;
        public AudioSource attackAudio;
        public AudioSource eDeath;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Velocidad máxima horizontal del jugador.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Velocidad incial del salto al empezar el salto.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        public Collider2D collider2d;
        public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;
        private bool stopJump;

        internal bossScript bossControl;

        //colisión ataque Yasu
        public Transform attackPoint;
        public Transform attackPoint2;
        public float attackRange = 0.5f;
        public LayerMask enemyLayers;

        //Variables Vial de sangre
        public TMPro.TextMeshProUGUI m_vialText;
        public int sangre = 0;

        //variable del tiempo para que no pueda atacar todo el rato:
        public float attackRate = 2f;
        float nextAttackTime = 0f;

        bool IsCrouched;
        bool IsAttacking;
        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;

        //Variables animación
        public Animator animator;
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
            //Llamar scripts y sus compenentes
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

        }

        protected override void Update()
        {
            //Movimiento y salto
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
            }
            else
            {
                IsCrouched = false;
            }

            //Condicional si Yasu Ataca

            if (Time.time >= nextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    IsAttacking = true;
                    Attack();
                    nextAttackTime = Time.time + 2f / attackRate;
                }
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {

                IsAttacking = false;
            }

            //Coger porcentaje de sangre y mostrarlo en pantalla
            m_vialText.SetText(sangre.ToString() + " %");
        }

        void ocultarRocas()
        {
            rocas.SetActive(false);
        }

        //Método de ataque de Yasu
        public void Attack()
        {
            attackAudio.Play();
            //hacer daño enemigos
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, enemyLayers);

            //Si golpea con el attackPoint a la capa de enemigo, este muere y suma 20 % al vial de sangre 
            foreach (Collider2D _collider in hitEnemies)
            {

                if (_collider.name == "Enemy1")
                {
                    animEn1.SetTrigger("death");
                    eDeath.Play();
                    sangre += 20;

                }
                else if (_collider.name == "Enemy2")
                {
                    animEn2.SetTrigger("death");
                    eDeath.Play();
                    sangre += 20;
                }
                else if (_collider.name == "Enemy3")
                {
                    animEn3.SetTrigger("death");
                    eDeath.Play();
                    sangre += 20;
                }
                else if (_collider.name == "Enemy4")
                {
                    animEn4.SetTrigger("death");
                    eDeath.Play();
                    sangre += 20;
                }
                else if (_collider.name == "Enemy5")
                {
                    animEn5.SetTrigger("death");
                    eDeath.Play();
                    Destroy(_collider);
                    sangre += 20;
                }
                else if (_collider.name == "Enemy6")
                {
                    animEn6.SetTrigger("isDead");
                    
                }

                ocultarRocas();
                _collider.enabled = false;
            }

            foreach (Collider2D _collider2 in hitEnemies2)
            {

                if (_collider2.name == "Enemy1")
                {
                    animEn1.SetTrigger("death");
                    eDeath.Play();
                    sangre += 20;
                }
                else if (_collider2.name == "Enemy2")
                {
                    animEn2.SetTrigger("death");
                    eDeath.Play();
                    sangre += 20;
                }
                else if (_collider2.name == "Enemy3")
                {
                    animEn3.SetTrigger("death");
                    eDeath.Play();
                    sangre += 20;
                }
                else if (_collider2.name == "Enemy4")
                {
                    animEn4.SetTrigger("death");
                    eDeath.Play();
                    sangre += 20;
                }
                else if (_collider2.name == "Enemy5")
                {
                    animEn5.SetTrigger("death");
                    eDeath.Play();
                    sangre += 20;
                }
                else if (_collider2.name == "Enemy6")
                {
                    
                    animEn6.SetTrigger("isDead");


                }

                ocultarRocas();
                _collider2.enabled = false;
            }
        }
    


        //Visualizar attackPoint
        void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

        //Corrección acciones de salto
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

        //Calcular velocidad salto y movimiento
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

        //Enum diferentes estados de salto
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