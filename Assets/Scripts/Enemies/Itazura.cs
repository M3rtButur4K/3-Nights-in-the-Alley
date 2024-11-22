using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [ENEMY SCRAPPED DUE TO AXEL NO LONGER WANTING
/// ANY OF THEIR CHARACTERS TO BE FEATURED] - M3rt
/// </summary>
public class Itazura : EnemyStats
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.CurrentState == GameManager.GameState.IsBeaten)
        {
            Destroy(this.gameObject);
        }
    }
}
