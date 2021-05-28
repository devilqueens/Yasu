using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverController : MonoBehaviour
{

    //Declaracion de gameobjects manuales
    public GameObject m_fondo = null;
    public GameObject m_gameOverText = null;
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
        LeanTween.alpha(m_gameOverText, 1f, 4f);
        if (timeNow > 4f)
        {
            m_clickToMainMenu.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
