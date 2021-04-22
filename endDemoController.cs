using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endDemoController : MonoBehaviour
{
    public GameObject m_fondo = null;
    public GameObject m_agradecimientos = null;
    public GameObject m_clickToMainMenu = null;

    public float timeNow = 0f;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.alpha(m_fondo, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeNow += Time.deltaTime;

        LeanTween.alpha(m_fondo, 1f, 2f);
        if(timeNow > 2f)
        {
            m_agradecimientos.SetActive(true);
        }
        if (timeNow > 4f)
        {
            m_clickToMainMenu.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
