using Platformer.Core;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;
using System.Collections;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Se ejecuta cuando la vida de el player llega a 0.
    /// </summary>
    /// <typeparam name="HealthIsZero"></typeparam>
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        //Declaración de script Health.
        public Health health;

        public override void Execute()
        {
            SceneManager.LoadScene("GameOver");

        }


    }
}