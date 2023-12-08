using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is for just the Options Menu - M3rt
/// </summary> 
public class OptionsMenu : MonoBehaviour
{
    [SerializeField] Resolution ScreenResolution;
    [SerializeField] public Toggle FullScreenToggle;

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
}
