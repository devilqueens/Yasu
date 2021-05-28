using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Representa la vida actual de la entidad.
    /// </summary>
    public class Health : MonoBehaviour
    {
        /// <summary>
        /// La vida máxima de la entidad.
        /// </summary>
        public int maxHP = 6;

        /// <summary>
        /// Indica si la entidad debería ser considerada 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        public int currentHP;

        /// <summary>
        /// Incrementa el HP de la entidad.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Reduce el HP de la entidad. Activara un evento de 'HealthIsZero' cuando el HP llegue a 0.
        /// </summary>
        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            if (currentHP == 0)
            {

                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }
        
        /// <summary>
        /// Reduce el HP de la entidad hasta llegar a 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        void Awake()
        {
            currentHP = maxHP;
        }
    }
}
