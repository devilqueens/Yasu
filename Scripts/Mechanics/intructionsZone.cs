using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Gameplay;
using Platformer.Mechanics;

public class intructionsZone : MonoBehaviour
{
    //Declaración variables
    public GameObject iCanvas;
    public GameObject iCanvas_2;
    public float timeGame = 0f;

    //Activa el iCanvas
    void Start()
    {
        iCanvas.SetActive(true);
    }

    //Si pasa X tiempo se desactiva el primer canvas y se activa el segundo canvas de instrucciones al dar clic, tras otro tiempo y clic, desactivas el segundo.
    void Update()
    {
        timeGame += Time.deltaTime;
        if ((timeGame > 1f)&&(Input.GetMouseButtonDown(0)))
        {
            iCanvas.SetActive(false);
            iCanvas_2.SetActive(true);

            if ((timeGame > 6f) && (Input.GetMouseButtonDown(0)))
            {

                iCanvas_2.SetActive(false);
            }
        }
    }


}
