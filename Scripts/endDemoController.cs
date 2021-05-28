using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endDemoController : MonoBehaviour
{
    //Declaracion de gameobjects manuales
    public GameObject m_fondo = null;
    public GameObject m_agradecimientos = null;
    public GameObject m_clickToMainMenu = null;

    //Declaracion de float tiempo
    public float timeNow = 0f;
    

    void Start()
    {

    }


    void Update()
    {
        //iniciar tiempo
        timeNow += Time.deltaTime;

        //Animación 
        LeanTween.alpha(m_fondo, 1f, 2f);
        if(timeNow > 2f)
        {
            m_agradecimientos.SetActive(true);
        }
        if (timeNow > 4f)
        {
            m_clickToMainMenu.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                //Escena MainMenu
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
