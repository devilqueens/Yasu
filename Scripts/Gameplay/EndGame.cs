using Platformer.Gameplay;
using UnityEngine;
using System.Collections;
using static Platformer.Core.Simulation;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Crea un trigger para la zona de Final de Juego.
    /// </summary>
    public class EndGame : MonoBehaviour
    {
        //Declaracion variable audio
        public AudioSource bloodSplash;

        //Si colisiona player con la zona 
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                StartCoroutine(End());
            }
        }

        private IEnumerator End()
        {
            //Iniciar sonido BloodSplash y delay 2 seg para cambiar escena
            bloodSplash.Play();
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("endDemoScene");
        }
    }
}