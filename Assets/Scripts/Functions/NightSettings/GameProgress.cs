using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "CurrentProgress", menuName = "GameProgress", order = 0)]

/// <summary>
/// This manages the progress of the game - M3rt
/// </summary>
public class GameProgress : ScriptableObject
{
    [SerializeField] protected NightSettings[] Nights;
    [SerializeField] protected NightSettings SpecialNight;
    [SerializeField] public NightSettings CurrentNight;
    [SerializeField] public int NightNumber;


    void Awake()
    {
        CurrentNight = Nights[NightNumber];
    }

    public void StartNewRun(int SceneNumber)
    {
        NightNumber = 0;
        CurrentNight = Nights[NightNumber];
        SceneManager.LoadScene(SceneNumber);
    }

    public void StartCurrentNight(int SceneNumber)
    {
        CurrentNight = Nights[NightNumber];
        SceneManager.LoadScene(SceneNumber);
    }

    public void StartSpecialNight(int SceneNumber)
    {
        CurrentNight = SpecialNight;
        SceneManager.LoadScene(SceneNumber);
    }
}
