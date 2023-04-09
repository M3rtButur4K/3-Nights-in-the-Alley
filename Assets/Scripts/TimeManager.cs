using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// This is for all the Time functions in the levels - M3rt
/// </summary> 
public class TimeManager : MonoBehaviour
{
    [SerializeField]
    float HourTime = 80;
    [SerializeField]
    int HourNumber;
    [SerializeField]
    GameObject[] TimeSprites;
    [SerializeField]
    GameObject CurrentHour;

    void Awake()
    {
        HourTime = 80;
        HourNumber = 0;
        CurrentHour = TimeSprites[HourNumber];
    }

    void FixedUpdate()
    {
        CurrentHour = TimeSprites[HourNumber];
        CurrentHour.SetActive(true);

        HourTime -= 1 * Time.deltaTime;
        if (HourTime <= 0)
        {
            SwitchHour();
        }
        if (HourNumber == 6)
        {
            EndNight();
        }
    }
    
    /// <summary>
    /// Switches the number of the current hour and restarts the Time until the next hour - M3rt
    /// </summary> 
    private void SwitchHour()
    {
        HourNumber += 1;
        SwitchSprite(HourNumber);
        HourTime = 80;
    }

    /// <summary>
    /// Switches the Sprite to the current hour - M3rt
    /// </summary> 
    public void SwitchSprite(int Number)
    {
        HourNumber = Number;

        foreach (GameObject sprite in TimeSprites)
        {
            sprite.SetActive(false);
        }
    }

    /// <summary>
    /// Ends The Night and then goes to the next one - M3rt
    /// </summary> 
    private void EndNight()
    {
        SceneManager.LoadScene(0);
    }
}
