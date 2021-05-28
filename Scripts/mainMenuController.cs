using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{

    //Declaracion de botones manuales
    public Button m_jButton;
    public Button m_sButton;

    //Declaracion booleanas
    public bool isStart;
    public bool isQuit;


    void Start()
    {
        //Boton 1 NewGame
        Button btn1 = m_jButton.GetComponent<Button>();
        btn1.onClick.AddListener(OnClickStart);

        //Boton 2 QuitGame
        Button btn2 = m_sButton.GetComponent<Button>();
        btn2.onClick.AddListener(OnClickQuit);
    }

    //Llama función OnMouseUp
    void Update()
    {
        OnMouseUp();
    }

    //Funcion de cambio de escena y salir Aplicación
    void OnMouseUp()
    {
        if (isStart == true)
        {
            SceneManager.LoadScene("gameScene");
        }
        if (isQuit == true)
        {
            Application.Quit();
        }
    }

    //Funciones de cambiar valor boolean
    private void OnClickStart()
    {
        isStart = true;
    }
    private void OnClickQuit()
    {
        isQuit = true;
    }
}
