using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class allyTalkZone : MonoBehaviour
{
    public GameObject allyTalkCanvas;
    public GameObject dobleSaltoCanvas;
    public GameObject allyTalk;
    public Animator animatorDJump;

    public Rigidbody2D RGB;
    public float jumpForce = 50f;

    public bool isDJump;
    public bool isDJumped;

    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        //empezar en false para evitar ejecuciones con antelación
        allyTalkCanvas.SetActive(false);
        dobleSaltoCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        //si usuario presiona ratón disable canvas
        if ((allyTalkCanvas == true)&&(Input.GetMouseButtonDown(0)))
        {
            allyTalkCanvas.SetActive(false);
        }
        if ((dobleSaltoCanvas == true) && (Input.GetMouseButtonDown(0)))
        {
            dobleSaltoCanvas.SetActive(false);
        }
        if (i == 2)
        {
            animatorDJump.SetBool("dJump", isDJump);
            animatorDJump.SetBool("dJumped", isDJumped);
            isDJump = true;
        }
        if ((isDJump == true) && (Input.GetKeyDown(KeyCode.S)))
        {
            RGB.velocity = new Vector2(0,10);
            RGB.AddForce(new Vector2(0, jumpForce));
            isDJumped = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isDJumped = false;
            RGB.velocity = new Vector2(0, 0);
            RGB.AddForce(new Vector2(0, 0));

        }
    }
    //Mostrar primer canvas en trigger
    void OnTriggerEnter2D(Collider2D collider)
    {
        var p = collider.gameObject.GetComponent<PlayerController>();
       
        if ((p != null)&&(i<1))
        {
            allyTalkCanvas.SetActive(true);
            i++;
            
        }
        StartCoroutine(ExecuteAfterTime(0));
        


    }
    //Mostrar segundo canvas
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(4);

        if (i == 1)
        {
            dobleSaltoCanvas.SetActive(true);
            i++;
            
        }
    }

}
