using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for the Character Sprites in the level - M3rt
/// </summary> 
public class CharacterSprite : MonoBehaviour
{
    [SerializeField] CameraManager Camera_Manager;
    [SerializeField] public Transform Looker;

    void Start()
    {
        Camera_Manager = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /// <summary>
        /// Sprite stares at the currently used Camera in the LEVEL
        /// (not just the one used in the Camera SYSTEM) - M3rt
        /// </summary>
        Looker.LookAt(Camera_Manager.CurrentCamera.transform);
    }
}
