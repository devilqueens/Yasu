using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJumpCueva : MonoBehaviour
{
    //Declaración de variables
    public GameObject djumpCueva;
    public Animator animatorDJump;
    public Rigidbody2D RGB;

    public float jumpForce = 50f;

    public bool isDJump;
    public bool isDJumped;

    void Start()
    {
        //Setear booleanos del animator de el Doble Salto
        animatorDJump.SetBool("dJump", isDJump);
        animatorDJump.SetBool("dJumped", isDJumped);

        //Declaramos el Doble Salto como true
        isDJump = true;
    }

    void Update()
    {
        //Si presiones S mientras DJumped sea true, hace Doble Salto
        if ((isDJump == true) && (Input.GetKeyDown(KeyCode.S)))
        {
            RGB.velocity = new Vector2(0, 10);
            RGB.AddForce(new Vector2(0, jumpForce));
            isDJumped = true;
        }
        //Si sueltas S, los valores de Doble Salto vuelven a 0
        if (Input.GetKeyUp(KeyCode.S))
        {
            isDJumped = false;
            RGB.velocity = new Vector2(0, 0);
            RGB.AddForce(new Vector2(0, 0));
        }
    }
}
