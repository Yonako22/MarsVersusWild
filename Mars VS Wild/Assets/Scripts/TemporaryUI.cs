using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TemporaryUI : MonoBehaviour
{

    public float wood;
    public float woodPerSecond = 1;
    [SerializeField] private bool quitOptions;
    public TextMeshProUGUI woodTxt;
    [SerializeField] private bool isPaused;
    public GameObject areUSureToQuit;
    public GameObject options;
    
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

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Options()
    {
        if (!quitOptions == false)
        {
            options.SetActive(true);

        }
        else
        {
            
        }
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
