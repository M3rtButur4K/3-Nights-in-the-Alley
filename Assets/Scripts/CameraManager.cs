using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script is responsible for the Camera functions in the levels - M3rt
/// </summary>
public class CameraManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] CameraScreens;
    [SerializeField]
    public GameObject CurrentCamera;
    [SerializeField]
    private int CameraNumber;
    [SerializeField]
    public bool IsCameraOn;
    [SerializeField]
    GameObject OfficeUI;
    [SerializeField]
    GameObject CameraUI;


    void Awake()
    {
        CurrentCamera = CameraScreens[CameraNumber];
    }

    public void Update()
    {
        CurrentCamera = CameraScreens[CameraNumber];
        CurrentCamera.SetActive(true);

        if (IsCameraOn == false)
        {
            CameraUI.SetActive(false);
            OfficeUI.SetActive(true);
        }
        if (IsCameraOn == true)
        {
            CameraUI.SetActive(true);
            OfficeUI.SetActive(false);
        }
    }

    public void SwitchCamera(int Number)
    {
        CameraNumber = Number;

        foreach (GameObject camera in CameraScreens)
        {
            camera.SetActive(false);
        }
    }

    public void SwitchUI(bool CameraSwitch)
    {
        IsCameraOn = CameraSwitch;
    }
}