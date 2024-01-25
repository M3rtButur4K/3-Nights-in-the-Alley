using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for the setting up the Enemies in an individual Night - M3rt
/// </summary>
[CreateAssetMenu(fileName = "Night", menuName = "NightSettings", order = 1)]
public class NightSettings : ScriptableObject
{
    CreateAssetMenuAttribute A;
    [Header("Enemies")]
    protected Discern E_Discern;
    public float DiscernNumber;

    protected Itazura E_Itazura;
    public float ItazuraNumber;
    
    protected Adam E_Adam;
    public float AdamNumber;
    
    protected Emma E_Emma;
    public float EmmaNumber;
    
    protected NemesisMetalSonic E_NMS;
    public float NMS_Number;
    
    protected Sardonyx E_Sardonyx;
    public float SardonyxNumber;
    
    protected RandomCharacter E_Random;
    public float RandomNumber;
    
    protected Jono E_Jono;
    public float JonoNumber;
    // for once i'm using a proper naming convention...only for the Classes - M3rt

    public void SetupEnemies()
    {
        //    SetUpDiscern();
        //    SetUpItazura();
        //    SetUpAdam();
        //    SetUpEmma();
        SetUpNMS();
        SetUpSardonyx();
        SetUpRandom();
        SetUpJono();
    }

    void SetUpDiscern()
    {
        E_Discern = FindObjectOfType<Discern>();
        E_Discern.AggressionLevel = DiscernNumber;
        if(E_Discern.AggressionLevel <= 0)
        {
            E_Discern.IsActive = false;
        }
    }
    void SetUpItazura()
    {
        E_Itazura = FindObjectOfType<Itazura>();
        E_Itazura.AggressionLevel = ItazuraNumber;
        if(E_Itazura.AggressionLevel <= 0)
        {
            E_Itazura.IsActive = false;
        }
    }
    void SetUpAdam()
    {
        E_Adam = FindObjectOfType<Adam>();
        E_Adam.AggressionLevel = AdamNumber;
        if(E_Adam.AggressionLevel <= 0)
        {
            E_Adam.IsActive = false;
        }
    }
    void SetUpEmma()
    {
        E_Emma = FindObjectOfType<Emma>();
        E_Emma.AggressionLevel = EmmaNumber;
        if (E_Emma.AggressionLevel <= 0)
        {
            E_Emma.IsActive = false;
        }
    }
    void SetUpNMS()
    {
        E_NMS = FindObjectOfType<NemesisMetalSonic>();
        E_NMS.AggressionLevel = NMS_Number;
        if(E_NMS.AggressionLevel <= 0)
        {
            E_NMS.IsActive = false;
        }
    }
    void SetUpSardonyx()
    {
        E_Sardonyx = FindObjectOfType<Sardonyx>();
        E_Sardonyx.AggressionLevel = SardonyxNumber;
        if(E_Sardonyx.AggressionLevel <= 0)
        {
            E_Sardonyx.IsActive = false;
        }
    }
    void SetUpRandom()
    {
        E_Random = FindObjectOfType<RandomCharacter>();
        E_Random.AggressionLevel = RandomNumber;
        if(E_Random.AggressionLevel <= 0)
        {
            E_Random.IsActive = false;
        }
    }
    void SetUpJono()
    {
        E_Jono = FindObjectOfType<Jono>();
        E_Jono.AggressionLevel = JonoNumber;
        if (E_Jono.AggressionLevel <= 0)
        {
            E_Jono.IsActive = false;
        }
    }
}
