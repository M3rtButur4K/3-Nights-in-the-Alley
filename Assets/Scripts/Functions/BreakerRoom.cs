using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is for the Functions in the Breaker Room - M3rt
/// </summary>
public class BreakerRoom : MonoBehaviour
{
    [SerializeField] protected CameraManager CameraSystem;
    [SerializeField] protected GameObject Room;
    OfficeManager Office;

    [Header("Room Functions")]
    [SerializeField] protected Button[] PowerButtons;
    public bool IsPowerOn;
    [SerializeField] protected Light RoomLight;

    void Start()
    {
        Office = FindObjectOfType<OfficeManager>();
        CameraSystem = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CameraSystem.CurrentCamera.name == "Breaker")
        {
            Room.SetActive(true);
        }
        else
        {
            Room.SetActive(false);
        }

        if(IsPowerOn)
        {
            RoomLight.gameObject.SetActive(true);
        }
        else
        {
            RoomLight.gameObject.SetActive(false);
        }
    }

    public void OpenPower()
    {
        if(Office.CurrentPower < 2)
        {
            Office.AddPower();
            IsPowerOn = true;
            PowerButtons[0].gameObject.SetActive(false);
            PowerButtons[1].gameObject.SetActive(true);
        }
        else
        {
            Office.ErrorSound.Play();
        }
    }

    public void ClosePower()
    {
        Office.RemovePower();
        IsPowerOn = false;
        PowerButtons[0].gameObject.SetActive(true);
        PowerButtons[1].gameObject.SetActive(false);
    }
}