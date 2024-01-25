using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for BLR/Afton's AI - M3rt
/// </summary>
public class RandomCharacter : EnemyStats
{

    [Header("Ability")]
    [SerializeField] protected BreakerRoom Breaker;
    [SerializeField] protected float SlowdownSpeed;

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

        BreakerState();

        if (TestMusic.time >= 25)
        {
            KillPlayer();
        }
        if (Manager.CurrentState == GameManager.GameState.IsBeaten || IsActive == false)
        {
            Destroy(this.gameObject);
        }
    }

    void BreakerState()
    {
        if (Breaker.IsPowerOn == true)
        {
            GoBack();
        }
        if (Breaker.IsPowerOn == false && Manager.CurrentState == GameManager.GameState.IsPlaying)
        {
            PlayMusic();
        }
        if (Breaker.IsPowerOn == false && Manager.CurrentState == GameManager.GameState.IsPaused)
        {
            TestMusic.Pause();
        }
    }

    void GoBack()
    {
        //TestMusic.volume = 0;
        TestMusic.Pause();
        if (TestMusic.time > 0)
        {
            TestMusic.time -= SlowdownSpeed * AggressionLevel * Time.deltaTime;
        }
    }

    void PlayMusic()
    {
        if(!TestMusic.isPlaying)
        {
            TestMusic.PlayScheduled(TestMusic.time);
        }
        //TestMusic.volume += 0.1f * Time.deltaTime;
    }
}