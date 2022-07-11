using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private bool unloaded;
    [SerializeField] private bool loaded;

    [SerializeField] private string PrevSceneName;
    [SerializeField] private string NextSceneName;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !unloaded)
        {
            UnLoadScene();
            unloaded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && !loaded)
        {
            LoadScene();
            loaded = true;
        }
    }

    private void LoadScene()
    {
        if (NextSceneName != string.Empty)
        {
            Debug.Log("LoadNext");
            SceneManager.LoadSceneAsync(NextSceneName, LoadSceneMode.Additive);
        }
    }

    private void UnLoadScene()
    {
        if (PrevSceneName != string.Empty)
        {
            Debug.Log("UnLoadPrev");
            SceneManager.UnloadSceneAsync(PrevSceneName);
        }
    }
}
