using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for Nemmy Metal's AI - M3rt
/// </summary>
public class NemesisMetalSonic : MonoBehaviour
{

    [SerializeField] protected BreakerRoom Breaker;
    GameManager Manager;

    [Header("Audio")]
    [SerializeField] protected AudioSource TestMusic;

    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        Breaker = FindObjectOfType<BreakerRoom>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Breaker.IsPowerOn == true && Manager.CurrentState == GameManager.GameState.IsPlaying)
        {
            PlayMusic();
        }
        if (Breaker.IsPowerOn == true && Manager.CurrentState == GameManager.GameState.IsPaused)
        {
            TestMusic.Stop();
        }
        if (Breaker.IsPowerOn == false)
        {
            GoBack();
        }


        if (TestMusic.time >= 35)
        {
            KillPlayer();
        }
    }

    void GoBack()
    {
        TestMusic.volume = 0;
        TestMusic.Stop();
    }

    void PlayMusic()
    {
        if (!TestMusic.isPlaying)
        {
            TestMusic.Play();
        }
        TestMusic.volume += 0.075f * Time.deltaTime;
    }

    void KillPlayer()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        manager.CurrentState = GameManager.GameState.IsDead;
        this.gameObject.SetActive(false);
    }
}
