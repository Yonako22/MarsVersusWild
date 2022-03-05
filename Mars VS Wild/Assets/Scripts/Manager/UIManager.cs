using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {

        public float wood;
        public float woodPerSecond = 1;
        public bool quitOptions;
        public TextMeshProUGUI woodTxt;
        [SerializeField] private bool isPaused;
        public GameObject areUSureToQuit;
        public GameObject options;
        public GameObject pauseMenu;
        public bool monkeyAvailable;
        public bool rhinoAvailable;
        public bool parrotAvailable;
        public bool GirafAvailable;
    
        void Start()
        {
            isPaused = false;
            quitOptions = false;
            wood = 1.5f;
            
            monkeyAvailable = false;
            rhinoAvailable = false;
            parrotAvailable = true;
            GirafAvailable = false;
        }
    
        void Update()
        {
            wood += Time.deltaTime * woodPerSecond;
            woodTxt.text = " " + (int)wood;
        }

        public void Resume()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    
        public void Pause()
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }

        public void Options()
        {
            if (quitOptions == false)
            {
                options.SetActive(true);
                quitOptions = true;
            }
            else
            {
                options.SetActive(false);
                quitOptions = false;
            }
        }

        public void Quit()
        {
            areUSureToQuit.SetActive(true);
        }

        public void NoIDontWantToQuit()
        {
            areUSureToQuit.SetActive(false);
        }
    
        public void YesIWantToQuit()
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        public void Gorilla()
        {
            
        }

        public void Girafe()
        {
            
        }

        public void Parrot()
        {
            
        }
        public void Rhino()
        {
            
        }

    }
}
