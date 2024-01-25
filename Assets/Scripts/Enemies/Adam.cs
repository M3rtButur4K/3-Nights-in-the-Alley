using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adam : EnemyStats
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
