using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TemporaryUI : MonoBehaviour
{

    public float wood;
    public float woodPerSecond = 1;
    private bool quitOptions;
    public TextMeshProUGUI woodTxt;
    [SerializeField] private bool isPaused;
    public GameObject areUSureToQuit;
    public GameObject options;
    
    void Start()
    {
        isPaused = false;
        
        wood = 1.5f;
    }
    
    void Update()
    {
        wood += Time.deltaTime * woodPerSecond;
        woodTxt.text = " " + (int)wood;
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
