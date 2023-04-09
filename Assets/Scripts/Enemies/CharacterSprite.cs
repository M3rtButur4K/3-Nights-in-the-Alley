using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSprite : MonoBehaviour
{
    [SerializeField] CameraManager Camera_Manager;
    [SerializeField] Transform Looker;

    void Start()
    {
        Camera_Manager = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Looker.LookAt(Camera_Manager.CurrentCamera.transform);
    }
}
