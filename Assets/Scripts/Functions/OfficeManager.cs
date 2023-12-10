using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Manages the functions for the Office - M3rt
/// </summary>
public class OfficeManager : MonoBehaviour
{
    [Header("Power Function")]
    [SerializeField] public int CurrentPower;
    [SerializeField] Slider PowerMeter;

    [Header("Sound Effects")]
    [SerializeField] public AudioSource ErrorSound;

    // Update is called once per frame
    void Update()
    {
        PowerMeter.value = CurrentPower;
    }

    /// <summary>
    /// Adds Power (unless its full) - M3rt
    /// </summary>
    public void AddPower()
    {
        if(CurrentPower < 2)
        {
            CurrentPower += 1;
        }
        else
        {
            ErrorSound.Play();
        }
    }
    /// <summary>
    /// Removes Power - M3rt
    /// </summary>
    public void RemovePower()
    {
        CurrentPower -= 1;
    }
}
