using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("SubMenus")] 
    
    public GameObject rulesMenu;
    public GameObject settingsMenu;

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

    public void SettingsExit()
    {
        settingsMenu.SetActive(false);
    }
    
    #endregion
}
