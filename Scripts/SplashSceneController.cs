using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneController : MonoBehaviour
{
    public static int SceneNumber;

    public GameObject m_name = null;
    public GameObject m_logo = null;
    public float timeNow = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneNumber == 0)
        {
            StartCoroutine(ToMainMenu());
        }

        m_name = GameObject.Find("nameDQueens");
        m_logo = GameObject.Find("logoDQueens");

        LeanTween.alpha(m_name, 0f, 0f);
        LeanTween.alpha(m_logo, 0f, 0f);

    }
    IEnumerator ToMainMenu()
    {
        yield return new WaitForSeconds(9);
        SceneNumber = 0;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        timeNow += Time.deltaTime;
        
        LeanTween.alpha(m_name, 1f, 5f);
        LeanTween.alpha(m_logo, 1f, 5f);
        if(timeNow > 5f)
        {
            LeanTween.alpha(m_logo, 0f, 3f);
            LeanTween.alpha(m_name, 0f, 3f);
            LeanTween.moveY(m_name, 800f, 4.2f);
            LeanTween.moveY(m_logo, 1000f, 4.2f);
        }
        


    }
}
