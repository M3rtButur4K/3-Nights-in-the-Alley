using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
/// <summary>
/// This is for the screen that shows you the current Night before you start - M3rt
/// </summary>
public class NightStartScreen : MonoBehaviour
{
    Scene Sample;
    [SerializeField] GameProgress Progress;
    [SerializeField] TextMeshProUGUI NightText;
    [SerializeField] TextMeshProUGUI ProgressText;
    [SerializeField] float TimeUntilLevelLoads;

    // Start is called before the first frame update
    void Start()
    {
        NightText.text = $"{Progress.CurrentNight.name}";
    }

    // Update is called once per frame
    void Update()
    {
        TimeUntilLevelLoads -= 1 * Time.deltaTime;
        if (TimeUntilLevelLoads <= 0)
        {
            ProgressText.text = $"LOADING";
            SceneManager.LoadSceneAsync(2);
        }
    }
}
