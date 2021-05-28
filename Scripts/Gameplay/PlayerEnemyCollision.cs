using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Se ejecuta cuando el jugador colisiona con un enemigo.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        //Declaraci�n variables
        public EnemyController enemy;
        public PlayerController player;
        public bossScript eBoss;
        public Enemy2Controller enemy2;

        GameObject gC;
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            //Busca al jugador y a su script de Health
            gC = GameObject.Find("Player");
            var GameCont = gC.GetComponent<Health>();

            //Si player entra en colisi�n con un enemigo se le restar� una vida

                if (GameCont.maxHP >= 1)
                {
                    GameCont.maxHP--;
                }

                if (GameCont.maxHP == 0)
                {
                    Schedule<PlayerDeath>();
                    GameCont.maxHP = 3;
                }
            
        }
    }
}