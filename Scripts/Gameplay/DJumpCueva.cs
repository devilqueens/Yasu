using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJumpCueva : MonoBehaviour
{

    public GameObject djumpCueva;
    public Animator animatorDJump;

    public Rigidbody2D RGB;
    public float jumpForce = 50f;

    public bool isDJump;
    public bool isDJumped;
    // Start is called before the first frame update
    void Start()
    {
        animatorDJump.SetBool("dJump", isDJump);
        animatorDJump.SetBool("dJumped", isDJumped);
        isDJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((isDJump == true) && (Input.GetKeyDown(KeyCode.S)))
        {
            RGB.velocity = new Vector2(0, 10);
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
}
