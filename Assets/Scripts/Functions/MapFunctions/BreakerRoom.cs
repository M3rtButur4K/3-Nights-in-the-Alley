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

    [Header("Room Functions")]
    [SerializeField] protected Button[] PowerButtons;
    public bool IsPowerOn;
    [SerializeField] protected Light RoomLight;

    void Start()
    {
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
            PowerButtons[0].gameObject.SetActive(false);
            PowerButtons[1].gameObject.SetActive(true);
        }
        else
        {
            RoomLight.gameObject.SetActive(false);
            PowerButtons[0].gameObject.SetActive(true);
            PowerButtons[1].gameObject.SetActive(false);
        }
    }

    public void SwitchPower(bool isOn)
    {
        IsPowerOn = isOn;
    }
}