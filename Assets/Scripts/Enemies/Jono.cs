using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jono : EnemyStats
{
    [Header("Rooom")]
    [SerializeField] protected CameraManager CameraSystem;
    [SerializeField] protected GameObject Room;

    [Header("Ability")]
    [SerializeField] protected float TimeToKill;
    [SerializeField] protected float RemainingTime;

    [SerializeField] protected float IncreaseTime;
    [SerializeField] protected float DecreaseTime;

    [Header("Progress Bar")]
    [SerializeField] protected Slider ProgressSlider;

    // Start is called before the first frame update
    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        CameraSystem = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RoomFunction();
        SliderFunction();

        if(RemainingTime >= TimeToKill)
        {
            KillPlayer();
        }
        if (Manager.CurrentState == GameManager.GameState.IsBeaten || IsActive == false)
        {
            Destroy(ProgressSlider.gameObject);
            Destroy(this.gameObject);
        }
    }

    void RoomFunction()
    {
        if (CameraSystem.CurrentCamera.name == "PreviewA")
        {
            Room.SetActive(true);
            if(RemainingTime > 0)
            {
                CountDownFunction(DecreaseTime / AggressionLevel);
            }
        }
        else
        {
            Room.SetActive(false);
            CountDownFunction(IncreaseTime * AggressionLevel);
        }
    } 

    void SliderFunction()
    {
        ProgressSlider.value = RemainingTime;
        ProgressSlider.maxValue = TimeToKill;
    }

    void CountDownFunction(float time)
    {
        RemainingTime += time * Time.deltaTime;
    }
}
