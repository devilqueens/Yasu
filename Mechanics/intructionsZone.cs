using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intructionsZone : MonoBehaviour
{
    public GameObject iCanvas;
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

        if (timeGame > 2f)
        {
            if (Input.GetMouseButtonDown(0))
            {

                iCanvas.SetActive(false);
            }
        }
        
    }
}
