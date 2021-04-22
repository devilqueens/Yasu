using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class exposes the the game model in the inspector, and ticks the
    /// simulation.
    /// </summary> 
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        //This model field is public and can be therefore be modified in the 
        //inspector.
        //The reference actually comes from the InstanceRegister, and is shared
        //through the simulation and events. Unity will deserialize over this
        //shared reference when the scene loads, allowing the model to be
        //conveniently configured inside the inspector.
        public PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        //-----------------------
        private int escControl = 0;
        public float timeGame = 0f;
        public bool isPaused = false;
        public bool isRestart = false;
        public bool isQuit = false;

        public GameObject pCanvas;

        public Button cButton;
        public Button rButton;
        public Button sButton;
        //-------------------------
        void OnEnable()
        {
            Instance = this;
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }
        void Start()
        {
            Button btn1 = cButton.GetComponent<Button>();
            btn1.onClick.AddListener(PauseFalse);
            Button btn2 = rButton.GetComponent<Button>();
            btn2.onClick.AddListener(OnClickRestart);
            Button btn3 = sButton.GetComponent<Button>();
            btn3.onClick.AddListener(OnClickQuit);
        }
        void Update()
        {
            if (Instance == this) Simulation.Tick();
            timeGame += Time.deltaTime;

            OnMouseUp();

            if (Input.GetKeyDown(KeyCode.Escape) && (escControl == 0))
            {
                isPaused = true;
                escControl = 1;

            }
            else if (Input.GetKeyDown(KeyCode.Escape) && (escControl == 1))
            {
                isPaused = false;
                escControl = 0;
            }

        }
        void OnMouseUp()
        {
            if (isPaused == true)
            {
                PauseGame();
            }
            if (isPaused == false)
            {
                ResumeGame();
            }
            if (isRestart == true)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (isQuit == true)
            {
                SceneManager.LoadScene(1);

            }
        }
        //Funcion pausa tiempo, activa PausaCanvas
        void PauseGame()
        {
            Time.timeScale = 0;


            pCanvas.SetActive(true);
            pCanvas.transform.GetChild(0).gameObject.SetActive(true);

        }
        //Funcion para el botón de continuar, vuelve pausa a false y escControl a 0
        void PauseFalse()
        {
            isPaused = false;
            escControl = 0;
        }
        //Funcion para volver al juego
        public void ResumeGame()
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            pCanvas.SetActive(false);

        }
        //Funcion para indicar reinicio
        public void OnClickRestart()
        {
            isRestart = true;

        }
        //Funcion para indicar isQuit true
        public void OnClickQuit()
        {
            isQuit = true;

        }
    }
}