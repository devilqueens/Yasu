using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Mechanics;
using UnityEngine.SceneManagement;


public class bossScript : MonoBehaviour
{
    //Declaración variables de Audio
    public AudioSource bossScream;
    public AudioSource bossMusic;
    public AudioSource bossDeath;

    //Declaración variables GameObject
    public GameObject bossMusicObj;
    public GameObject attackPoint;
    public GameObject attackPoint2;
    GameObject gC;

    //Declarar al script PlayerController
    public PlayerController classPlayer;

    void Start()
    {
        //Iniciar los GameObjects en false
        attackPoint.SetActive(false);
        attackPoint2.SetActive(false);

        //Iniciar Musica
        bossScream.Play();
        bossMusic.Play();
    }

    void Update()
    {
        //Si clicamos Z, llama función Attack de PlayerController y se activan los GameObjects
        if (Input.GetKeyDown(KeyCode.Z))
        {
            attackPoint.SetActive(true);
            attackPoint2.SetActive(true);
            classPlayer.Attack();
        } 
    }
    //Detectar la colisión de player y restar vida a Yasu, detectar los AttackPoint y llamar ControlMusicBoss
    void OnCollisionEnter2D(Collision2D collision)
    {
        gC = GameObject.Find("Player");
        var GameCont = gC.GetComponent<Health>();
        var attackPoint = collision.gameObject.GetComponent<PlayerController>();
        var attackPoint2 = collision.gameObject.GetComponent<PlayerController>();
        var player = collision.gameObject.GetComponent<PlayerController>();
        if(player != null)
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

        if (attackPoint != null)
        {
            StartCoroutine(controlMusicBoss());

        }

        if (attackPoint2 != null)
        {
            StartCoroutine(controlMusicBoss());
        }
    }
    //Delay para parar musica
    IEnumerator controlMusicBoss()
    {
            yield return new WaitForSeconds(1.0f);
            bossScream.Stop();
            bossMusic.Stop();
    }
}
