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
    [SerializeField] AudioSource ErrorSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerMeter.value = CurrentPower;
    }

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

    public void RemovePower()
    {
        CurrentPower -= 1;
    }
}
