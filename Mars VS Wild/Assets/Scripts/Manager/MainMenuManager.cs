using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    [Header("Resolution")]
    
    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    [Header("SubMenus")] 
    
    public GameObject rulesMenu;
    public GameObject settingsMenu;

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

    #region MainMenu
    
    public void StartGame()
    {
        Debug.Log("Start");
    }

    public void Rules()
    {
        rulesMenu.SetActive(true);
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
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

    public void SetVolume(float _volume) // Volume
    {
        audioMixer.SetFloat("Volume", _volume);
    }

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
}
