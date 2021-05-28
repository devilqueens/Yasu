using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Este componente es usado para crear un recorrido entre dos puntos donde el enemigo se mover� entre ellos.
    /// </summary>
    public partial class PatrolPath : MonoBehaviour
    {
        //Declaraci�n variables posici�n
        public Vector2 startPosition, endPosition;

        /// <summary>
        /// Crea una instacia del m�todo Mover usado para mover la entidad a lo largo del recorrido a cierta velocidad.
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public Mover CreateMover(float speed = 1) => new Mover(this, speed);

        void Reset()
        {
            startPosition = Vector3.left;
            endPosition = Vector3.right;
        }
    }
}