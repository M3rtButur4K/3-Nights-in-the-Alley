using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for the basic Enemy stats for all of them - M3rt
/// </summary>
public class EnemyStats : MonoBehaviour
{
    [SerializeField] public bool IsActive;
    [SerializeField] public float AggressionLevel;
    [SerializeField] protected GameManager Manager;

    public void KillPlayer()
    {
        Manager.CurrentState = GameManager.GameState.IsDead;
        this.gameObject.SetActive(false);
    }
}
