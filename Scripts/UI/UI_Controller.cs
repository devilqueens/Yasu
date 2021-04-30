using Platformer.Mechanics;
using System.Collections;
using Platformer.Gameplay;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{

    public GameObject m_corVida_3 = null;
    public GameObject m_corVida_2 = null;
    public GameObject m_corVida_1 = null;
    public GameObject m_vialText = null;

    //public int hearts;
    protected Health hearts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hearts = Health.currentHP;

        //if (hearts.currentHP == 2)
        //{
        //    m_corVida_3.SetActive(false);
        //}
        //if (hearts.currentHP == 1)
        //{
        //    m_corVida_2.SetActive(false);
        //}
        //if (hearts.currentHP == 0)
        //{
        //    m_corVida_1.SetActive(false);
        //}
    }
}
