using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseEffect : MonoBehaviour
{
    public float NoiseTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NoiseTime -= 1 * Time.deltaTime;
        if(NoiseTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
