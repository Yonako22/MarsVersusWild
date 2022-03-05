using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TemporaryUI : MonoBehaviour
{

    public float wood;
    public float woodPerSecond = 1;
    public bool quitOptions;
    public TextMeshProUGUI woodTxt;
    [SerializeField] private bool isPaused;
    public GameObject areUSureToQuit;
    public GameObject options;
    public GameObject pauseMenu;
    
    void Start()
    {
        isPaused = false;
        quitOptions = false;
        wood = 1.5f;
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
    
}
