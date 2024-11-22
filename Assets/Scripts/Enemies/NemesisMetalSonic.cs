using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is for Nemmy Metal's AI - M3rt
/// </summary>
public class NemesisMetalSonic : EnemyStats
{

    [Header("Ability")]
    [SerializeField] protected BreakerRoom Breaker;
    [SerializeField] protected float SlowdownSpeed;

    [Header("Progress Bar")]
    [SerializeField] protected Slider ProgressSlider;

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
        ProgressSlider.gameObject.SetActive(true);
        ProgressSlider.value = TestMusic.time;

        BreakerState();

        if (TestMusic.time >= 210)
        {
            KillPlayer();
        }
        if (Manager.CurrentState == GameManager.GameState.IsBeaten || IsActive == false)
        {
            Destroy(ProgressSlider.gameObject);
            Destroy(this.gameObject);
        }
    }

    void BreakerState()
    {
        if (Breaker.IsPowerOn == true && Manager.CurrentState == GameManager.GameState.IsPlaying)
        {
            PlayMusic();
        }
        if (Breaker.IsPowerOn == true && Manager.CurrentState == GameManager.GameState.IsPaused)
        {
            TestMusic.Pause();
        }
        if (Breaker.IsPowerOn == false)
        {
            StopBuilding();
        }
    }

    void StopBuilding()
    {
        //TestMusic.volume = 0;
        TestMusic.Pause();
        if (TestMusic.time > 0)
        {
            TestMusic.time -= SlowdownSpeed / AggressionLevel * Time.deltaTime;
        }
    }

    void PlayMusic()
    {
        if (!TestMusic.isPlaying)
        {
            TestMusic.PlayScheduled(TestMusic.time);
        }
        //TestMusic.volume += 0.075f * Time.deltaTime;
    }
}
