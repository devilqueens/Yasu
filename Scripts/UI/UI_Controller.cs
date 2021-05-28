using Platformer.Mechanics;
using System.Collections;
using Platformer.Gameplay;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Controller : MonoBehaviour
{
    //Declaración de variables
    public GameObject m_corVida_3 = null;
    public GameObject m_corVida_2 = null;
    public GameObject m_corVida_1 = null;

    internal Health hearts = null;
    GameObject gC;

    void Start()
    {
        gC = GameObject.Find("Player");
    }

    void Update()
    {

        restaVida();
        
    }

    //Llamamos al script Health, e indicamos que desactivamos corazones si falta vida.
    void restaVida()
    {
        var hearts = gC.GetComponent<Health>();
        if (hearts.maxHP == 2)
        {
            m_corVida_3.SetActive(false);
        }
        if (hearts.maxHP == 1)
        {
            m_corVida_2.SetActive(false);
        }
        if (hearts.maxHP == 0)
        {
            m_corVida_1.SetActive(false);
        }
    }

}
