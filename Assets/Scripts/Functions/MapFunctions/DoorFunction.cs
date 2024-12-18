using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script is for the Door functions - M3rt
/// </summary>
public class DoorFunction : MonoBehaviour
{
    OfficeManager Office;

    [Header("Door")]
    [SerializeField] protected GameObject DoorObject;
    [SerializeField] protected enum DoorState
    {
        Closed,
        Open
    }
    [SerializeField] protected DoorState CurrentState;

    [Header("Button")]
    [SerializeField] protected MeshRenderer ButtonMaterial;
    [SerializeField] protected Material[] ButtonColors;

    [Header("UI")]
    [SerializeField] protected GameObject[] UIButtons;

    [Header("Sound Effects")]
    [SerializeField] protected AudioSource DoorAudio;
    [SerializeField] protected AudioClip[] DoorSounds;
    [SerializeField] protected GameObject SoundObject;

    // Start is called before the first frame update
    void Start()
    {
        Office = FindObjectOfType<OfficeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /// <summary>
        /// This part manages the stuff that happens on the current Door state - M3rt
        /// </summary>
        switch (CurrentState)
        {
            case DoorState.Closed:
                DoorObject.SetActive(true);
                ButtonMaterial.material = ButtonColors[1];
                UIButtons[0].SetActive(false);
                UIButtons[1].SetActive(true);
                break;
            case DoorState.Open:
                DoorObject.SetActive(false);
                ButtonMaterial.material = ButtonColors[0];
                UIButtons[0].SetActive(true);
                UIButtons[1].SetActive(false);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Closes the Door (if you're not using all power) - M3rt
    /// </summary>
    public void CloseDoor()
    {
        if (Office.CurrentPower < 2)
        {
            Office.AddPower();
            DoorAudio.clip = DoorSounds[0];
            DoorAudio.Play();
            CurrentState = DoorState.Closed;
            Instantiate(SoundObject, DoorObject.transform.position, Quaternion.identity);
        }
        else
        {
            Office.ErrorSound.Play();
        }
    }
    /// <summary>
    /// Opens the Door - M3rt
    /// </summary>
    public void OpenDoor()
    {
        Office.RemovePower();
        DoorAudio.clip = DoorSounds[1];
        DoorAudio.Play();
        CurrentState = DoorState.Open;
        Instantiate(SoundObject, DoorObject.transform.position, Quaternion.identity);
    }
}
