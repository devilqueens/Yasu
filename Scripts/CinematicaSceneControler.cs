using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicaSceneControler : MonoBehaviour
{
    //Declaración variables
    float timeC = 0f;
    public GameObject textSaltar;

    void Start()
    {
        
    }

    //Cargar siguiente escena, saltar cinematica si haces clic.
    void Update()
    {
        timeC += Time.deltaTime;
        if (timeC> 5f && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (timeC > 69f)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (timeC > 5f)
        {
            textSaltar.SetActive(true);
        }
    }
}
