using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    public static int SceneNumber;

    public Button m_jButton;
    public Button m_sButton;
    public bool isStart;
    public bool isQuit;
    // Start is called before the first frame update
    void Start()
    {
        
        //if (SceneNumber == 1)
        //{
        //    StartCoroutine(ToGame());
        //}
        Button btn1 = m_jButton.GetComponent<Button>();
        btn1.onClick.AddListener(OnClickStart);
        Button btn2 = m_sButton.GetComponent<Button>();
        btn2.onClick.AddListener(OnClickQuit);

        
    }

    // Update is called once per frame
    void Update()
    {

        OnMouseUp();
    }
    void OnMouseUp()
    {
        if (isStart == true)
        {
            SceneManager.LoadScene(2);
        }
        if (isQuit == true)
        {
            Application.Quit();
        }
    }
    private void OnClickStart()
    {
        isStart = true;

    }
    private void OnClickQuit()
    {
        isQuit = true;

    }
}
