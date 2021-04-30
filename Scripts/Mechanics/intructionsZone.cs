using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;
using Platformer.Gameplay;
using Platformer.Mechanics;

public class intructionsZone : MonoBehaviour
{
    public GameObject iCanvas;
    public GameObject iCanvas_2;
    public float timeGame = 0f;
    // Start is called before the first frame update
    void Start()
    {
        iCanvas.SetActive(true);
    }


    // Update is called once per frame
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
