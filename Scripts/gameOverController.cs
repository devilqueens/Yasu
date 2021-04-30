using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverController : MonoBehaviour
{
    public static int SceneNumber;

    public GameObject m_fondo = null;
    public GameObject m_gameOverText = null;
    public GameObject m_clickToMainMenu = null;

    public float timeNow = 0f;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.alpha(m_fondo, 0f, 0f);
        LeanTween.alpha(m_gameOverText, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeNow += Time.deltaTime;

        LeanTween.alpha(m_fondo, 1f, 2f);
        LeanTween.alpha(m_gameOverText, 1f, 4f);
        if (timeNow > 4f)
        {
            m_clickToMainMenu.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
