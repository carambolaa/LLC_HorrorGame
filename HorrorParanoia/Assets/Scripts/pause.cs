using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject PauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }

    }
    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
