using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Trigger cambio de escena a cueva.
    /// </summary>
    public class VictoryZone : KinematicObject
    {
        public PlayerController player;
        public GameObject sCanvas;

        //Si player entra en colisión y tiene la sangre suficiente, cambia de escena, en caso de no tener sangre suficiente, te salta un mensaje.
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if ((p != null)&&(player.sangre == 100))
            {
                SceneManager.LoadScene("Escena2");
                
            }
            if (p != null && player.sangre < 100)
            {
                sCanvas.SetActive(true);

            }
            else
            {
                sCanvas.SetActive(false);

            }
        }

    }
}