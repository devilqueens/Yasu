using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Mechanics;
using UnityEngine.SceneManagement;

public class Enemy2Controller : MonoBehaviour
{
    //Declaración Enemigo 2 y variable de cambio de estado
    public GameObject enemy2;
    GameObject gC;

    void Update()
    {

    }
    //Si entra en colisión cambie el estado a 1
    void OnCollisionEnter2D(Collision2D collision)
    {
        gC = GameObject.Find("Player");
        var GameCont = gC.GetComponent<Health>();
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            if (GameCont.maxHP >= 1)
            {
                GameCont.maxHP--;
            }

            if (GameCont.maxHP == 0)
            {
                SceneManager.LoadScene("GameOver");
            }

        }
    }
}
