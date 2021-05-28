using UnityEngine;

namespace Platformer.Mechanics
{
    public partial class PatrolPath
    {
        /// <summary>
        /// Clase de movimiento que oscila entre los puntos de incio y final del recorrido a una velocidad definida.
        /// </summary>
        public class Mover
        {
            //Declaraci�n variables
            PatrolPath path;
            float p = 0;
            float duration;
            float startTime;

            //M�todo para normalizar la velocidad, partiendo de la magnitud del recorrido
            public Mover(PatrolPath path, float speed)
            {
                this.path = path;
                this.duration = (path.endPosition - path.startPosition).magnitude / speed;
                this.startTime = Time.time;
            }

            /// <summary>
            /// Devuelve la informaci�n de la posici�n al m�todo Mover en el frame actual.
            /// </summary>
            /// <value></value>
            public Vector2 Position
            {
                get
                {
                    p = Mathf.InverseLerp(0, duration, Mathf.PingPong(Time.time - startTime, duration));
                    return path.transform.TransformPoint(Vector2.Lerp(path.startPosition, path.endPosition, p));
                }
            }
        }
    }
}