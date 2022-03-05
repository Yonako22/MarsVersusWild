using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool quitOptions;
    public TextMeshProUGUI woodTxt;
    [SerializeField] private bool isPaused;
    public GameObject areUSureToQuit;
    public GameObject options;
    
    void Start()
    {
        isPaused = false;
    }
    
    void Update()
    {
        woodTxt.text = " " + (int)GameManager.instance.wood;
    }

    public void Pause()
    {
        if (!quitOptions)
        {
            
        }
        Time.timeScale = 0f;
    }

    public void Options()
    {
        options.SetActive(true);
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
