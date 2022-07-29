using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinishScene : MonoBehaviour
{
    public bool canFinish = false;

    public void LoadLastScene()
    {
        if(canFinish)
        {
            SceneManager.LoadScene(12);
        }
    }
}
