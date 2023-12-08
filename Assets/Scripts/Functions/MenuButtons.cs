using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This is for all the baic buttons used in a menu - M3rt
/// </summary> 
public class MenuButtons : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    /// <summary>
    /// This loads the selected level/scene - M3rt
    /// </summary> 
    public void SwitchScene(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }

    /// <summary>
    /// Closes the game - M3rt
    /// </summary> 
    public void ExitGame()
    {
        Application.Quit();
    }
}