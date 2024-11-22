using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightWinScreen : MonoBehaviour
{
    [SerializeField] AudioSource WinSound;

    // Update is called once per frame
    void Update()
    {
        if(!WinSound.isPlaying)
        {
            SceneManager.LoadScene(0);
        }
    }
}
