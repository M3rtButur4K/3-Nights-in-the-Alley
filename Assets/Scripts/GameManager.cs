using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("States")]
    string sampletext; //does nothing just so that the editor shows the "States" part - M3rt
    [SerializeField] public enum GameState
    {
        IsPlaying,
        IsPaused,
        IsDead,
    }
    [SerializeField] public GameState CurrentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchStates()
    {

    }

    void IsPlaying()
    {

    }
    void IsPaused()
    {

    }
    void IsDead()
    {

    }
}
