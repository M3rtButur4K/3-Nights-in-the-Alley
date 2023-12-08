using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script is responsible for the Camera functions in the levels - M3rt
/// </summary>
public class CameraManager : MonoBehaviour
{
    OfficeManager Office;

    [Header("Cameras")]
    [SerializeField] protected GameObject[] CameraScreens;
    [SerializeField] protected GameObject OfficeCamera;
    [SerializeField] public GameObject CurrentCamera;
    [SerializeField] private int CameraNumber;
    [SerializeField] protected enum IsCameraOn
    {
        Off,
        On
    }
    [SerializeField] protected IsCameraOn CameraState;

    [Header("UI")]
    [SerializeField] GameObject OfficeUI;
    [SerializeField] GameObject CameraUI;

    [Header("Sound Effects")]
    [SerializeField] AudioSource CameraAudio;
    [SerializeField] AudioClip[] CameraSounds;


    void Start()
    {
        Office = FindObjectOfType<OfficeManager>();
        CurrentCamera = OfficeCamera;
    }

    public void Update()
    {
        CurrentCamera.SetActive(true);

        switch (CameraState)
        {
            case IsCameraOn.Off:
                for (int i = 0; i < CameraScreens.Length; i++)
                {
                    CameraScreens[i].SetActive(false);
                }
                CurrentCamera = OfficeCamera;
                CameraUI.SetActive(false);
                OfficeUI.SetActive(true);
                break;
            case IsCameraOn.On:
                OfficeCamera.SetActive(false);
                CurrentCamera = CameraScreens[CameraNumber];
                CameraUI.SetActive(true);
                OfficeUI.SetActive(false);
                break;
            default:
                break;
        }
    }

    public void SwitchCamera(int Number)
    {
        CameraNumber = Number;

        foreach (GameObject camera in CameraScreens)
        {
            camera.SetActive(false);
        }
        CameraAudio.clip = CameraSounds[2];
        CameraAudio.Play();
    }

    public void TurnOnCamera()
    {
        if(Office.CurrentPower < 2)
        {
            Office.AddPower();
            CameraAudio.clip = CameraSounds[0];
            CameraAudio.Play();
            CameraState = IsCameraOn.On;
        }
    }
    public void TurnOffCamera()
    {
        Office.RemovePower();
        CameraAudio.clip = CameraSounds[1];
        CameraAudio.Play();
        CameraState = IsCameraOn.Off;
    }
}