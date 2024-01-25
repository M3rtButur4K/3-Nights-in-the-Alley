using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is where all the Keyboard functions for the levels are - M3rt
/// </summary>
public class KeyboardControls : MonoBehaviour
{
    [SerializeField] GameManager Manager;

    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && Manager.CurrentState == GameManager.GameState.IsPlaying)
        {
            Manager.CurrentState = GameManager.GameState.IsPaused;
        }
    }
}
