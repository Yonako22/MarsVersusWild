using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public float wood;
        public float woodPerSecond = 1;
        public bool quitOptions;
        public TextMeshProUGUI woodTxt;
        public bool isPaused;
        public GameObject areUSureToQuit;
        public GameObject options;
        public GameObject pauseMenu;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Bruuuuuhhh");
                return;
            }
            instance = this;
        }

        void Start()
        {
            isPaused = false;
            quitOptions = false;
            wood = 1.5f;
        }
    
        void Update()
        {
            wood += Time.deltaTime * woodPerSecond;
            woodTxt.text =  Mathf.RoundToInt(GameManager.instance.wood).ToString();
        }

        public void Resume()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    
        public void Pause()
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            isPaused = true;
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
    }
}
