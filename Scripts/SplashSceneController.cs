using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneController : MonoBehaviour
{
    //Declaracion de gameobjects 
    public GameObject m_name = null;
    public GameObject m_logo = null;

    //Declaracion de float tiempo
    public float timeNow = 0f;

    void Start()
    {
        //Llamamos a la función ToMainMenu
        StartCoroutine(ToMainMenu());

        //Buscar los sprites en Unity
        m_name = GameObject.Find("nameDQueens");
        m_logo = GameObject.Find("logoDQueens");

        //Inicio animación en 0
        LeanTween.alpha(m_name, 0f, 0f);
        LeanTween.alpha(m_logo, 0f, 0f);
    }
    //Funcion con delay para el cambio de escena
    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(9);
        SceneManager.LoadScene("CinematicaScene");
    }

    void Update()
    {
        //iniciar tiempo
        timeNow += Time.deltaTime;

        //Animación 
        LeanTween.alpha(m_name, 1f, 5f);
        LeanTween.alpha(m_logo, 1f, 5f);
        if(timeNow > 5f)
        {
            LeanTween.alpha(m_logo, 0f, 3f);
            LeanTween.alpha(m_name, 0f, 3f);
            LeanTween.moveY(m_name, 800f, 4.2f);
            LeanTween.moveY(m_logo, 1000f, 4.2f);
        }
    }
}
