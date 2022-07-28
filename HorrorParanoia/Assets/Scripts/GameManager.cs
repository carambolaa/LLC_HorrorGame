using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int targetFrameRate = 120;
    private void Awake()
    {
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    private void Start()
    {
        if(!SceneManager.GetSceneByBuildIndex(2).isLoaded)
        {
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        }
    }
}
