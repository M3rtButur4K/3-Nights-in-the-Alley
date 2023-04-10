using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This is for all the Buttons used in the Menu - M3rt
/// </summary> 
public class MenuButtons : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] Resolution ScreenResolution;
    [SerializeField] public Toggle FullScreenToggle;

    #region Menues
    // This is for the Panels like the Main Menu, Options, etc. - M3rt

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    #endregion

    /// <summary>
    /// This loads the selected level/scene - M3rt
    /// </summary> 
    public void SwitchScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }

    #region Options
    // This is for the Options Menu - M3rt
    
    public void FullScreenMode()
    {
        Screen.fullScreen = FullScreenToggle.isOn;
    }

    public void ChangeWidth(int Width)
    {
        ScreenResolution.width = Width;
        Screen.SetResolution(ScreenResolution.width, ScreenResolution.height, Screen.fullScreen = FullScreenToggle.isOn);
    }
    public void ChangeHeight(int Height)
    {
        ScreenResolution.height = Height;
        Screen.SetResolution(ScreenResolution.width, ScreenResolution.height, Screen.fullScreen = FullScreenToggle.isOn);
    }
    #endregion

    /// <summary>
    /// Closes the game - M3rt
    /// </summary> 
    public void ExitGame()
    {
        Application.Quit();
    }
}
