using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// This is for the main Time functions in the levels - M3rt
/// </summary> 
public class TimeManager : MonoBehaviour
{
    [SerializeField] GameManager Manager;

    [Header("Time")]
    [SerializeField] float HourTime = 80;
    [SerializeField]
    int HourNumber;

    [Header("Sprites")]
    [SerializeField] GameObject[] TimeSprites;
    [SerializeField] GameObject CurrentHour;

    void Awake()
    {
        HourTime = 80;
        HourNumber = 0;
        CurrentHour = TimeSprites[HourNumber];
    }

    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        CurrentHour = TimeSprites[HourNumber];
        CurrentHour.SetActive(true);

        if (Manager.CurrentState != GameManager.GameState.IsBeaten)
        {
            HourTime -= 1 * Time.deltaTime;
        }
        if (HourTime <= 0)
        {
            SwitchHour();
        }
        if (HourNumber == 6 && Manager.CurrentState == GameManager.GameState.IsPlaying)
        {
            EndNight();
        }
    }
    
    /// <summary>
    /// Switches the number of the current hour and resets the HourTime - M3rt
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
    /// Tells the GameManager to end the night - M3rt
    /// </summary> 
    private void EndNight()
    {
        Manager.CurrentState = GameManager.GameState.IsBeaten;
    }
}
