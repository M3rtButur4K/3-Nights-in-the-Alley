using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This is where all the Keyboard functions for the levels are - M3rt
/// </summary>
public class KeyboardControls : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
