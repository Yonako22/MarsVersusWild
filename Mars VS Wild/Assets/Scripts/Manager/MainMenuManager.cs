using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Resolution")]
    
    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    [Header("SubMenus")] 
    
    public GameObject rulesMenu;
    public GameObject settingsMenu;
    public GameObject creditsMenu;

    [Header("Backgrounds")] 
    public GameObject background;
    public Sprite backgroundSun;
    public Sprite backgroundNight;

    public bool sun;

    public Image sunButton;
    public Image nightButton;

    public void Awake()
    {
        background.GetComponent<Image>().sprite = backgroundSun;
        sun = true;
    }
    
    public void Start() //Recherche des résolutions disponibles
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Update()
    {
        if (sun)
        {
            sunButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            nightButton.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1f);
        }
        else
        {
            nightButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            sunButton.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 1f);
        }
    }

    #region MainMenu
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Rules()
    {
        if (!rulesMenu.activeSelf)
        {
            rulesMenu.SetActive(true);
            settingsMenu.SetActive(false);
            creditsMenu.SetActive(false);
        }
        else
        {
            rulesMenu.SetActive(false);
        }
    }

    public void Settings()
    {
        if (!settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(true);
            rulesMenu.SetActive(false);
            creditsMenu.SetActive(false);
        }
        else
        {
            settingsMenu.SetActive(false);
        }
    }

    public void Credits()
    {
        if (!creditsMenu.activeSelf)
        {
            creditsMenu.SetActive(true);
            rulesMenu.SetActive(false);
            settingsMenu.SetActive(false);
        }
        else
        {
            creditsMenu.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    #endregion
    
    #region Rules

    public void RulesExit()
    {
        rulesMenu.SetActive(false);
    }
    
    #endregion
    
    #region Settings
    
    public void SetFullScreen(bool _isFullScreen)
    {
        Screen.fullScreen = _isFullScreen;
    }

    public void SetResolution(int _resolutionIndex)
    {
        Resolution resolution = resolutions[_resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SettingsExit()
    {
        settingsMenu.SetActive(false);
    }
    
    #endregion
    
    #region Credits

    public void CreditsExit()
    {
        creditsMenu.SetActive(false);
    }
    
    #endregion

    #region Night and Day
    
    public void Sun()
    {
        sun = true;
        background.GetComponent<Image>().sprite = backgroundSun;
    }

    public void Night()
    {
        sun = false;
        background.GetComponent<Image>().sprite = backgroundNight;
    }
    
    #endregion
}
