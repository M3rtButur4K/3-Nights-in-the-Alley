using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This manages the states of the level - M3rt
/// </summary> 
public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameProgress CurrentProgress;

    [Header("Player")]
    [SerializeField] public Transform PlayerPosition;

    [Header("States")]
    string sampletext; // Is just there so the editor shows the "States" part - M3rt
    [SerializeField] public enum GameState
    {
        IsPlaying,
        IsPaused,
        IsBeaten,
        IsDead,
    }
    [SerializeField] public GameState CurrentState;

    [Header("Panels")]
    [SerializeField] public GameObject IngamePanel;
    [SerializeField] public GameObject PausePanel;
    [SerializeField] public GameObject VictoryPanel;
    [SerializeField] public GameObject GameOverPanel;

    [Header("GameOverStuff")]
    [SerializeField] AudioSource JumpscareSound;

    // Start is called before the first frame update
    void Start()
    {
        //CurrentProgress.CurrentNight.SetupEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchStates();
    }

    /// <summary>
    /// This switches the current game state - M3rt
    /// </summary> 
    void SwitchStates()
    {
        switch (CurrentState)
        {
            case GameState.IsPlaying:
                IsPlaying();
                break;
            case GameState.IsPaused:
                IsPaused();
                break;
            case GameState.IsBeaten:
                IsBeaten();
                break;
            case GameState.IsDead:
                IsDead();
                break;
            default:
                break;
        }
    }

    #region Individual States
    void IsPlaying()
    {
        Time.timeScale = 1;
        IngamePanel.SetActive(true);
        PausePanel.SetActive(false);
    }
    void IsPaused()
    {
        Time.timeScale = 0;
        IngamePanel.SetActive(false);
        PausePanel.SetActive(true);
    }
    void IsBeaten()
    {
        IngamePanel.SetActive(false);
        PausePanel.SetActive(false);
        VictoryPanel.SetActive(true);
        SceneManager.LoadScene(4);
    }
    void IsDead()
    {
        IngamePanel.SetActive(false);
        PausePanel.SetActive(false);
        GameOverPanel.SetActive(true);
        if(!JumpscareSound.isPlaying)
        {
            SceneManager.LoadScene(3);
        }
    }
    #endregion

    #region Button Functions
    public void ContinueGame()
    {
        CurrentState = GameState.IsPlaying;
    }
    #endregion
}
