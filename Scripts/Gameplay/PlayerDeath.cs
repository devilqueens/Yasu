using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Se ejecuta cuando el player "muere".
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        //Llama al controlador del modelo de plataforma.
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            //Declaramos al player
            var player = model.player;

            //Si esta vivo el player se le declara muerto, se desactiva el control, y las camaras dejan de seguirlo
            if (player.health.IsAlive)
            {
                player.health.Die();
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;

                //Ejecuta sonido ouch de player
                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);

                //Ejecutar animacion de daño y cambiar bool de muerte a true
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);
            }
        }
    }
}