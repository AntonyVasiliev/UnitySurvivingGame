using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool inmenu = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!inmenu) Pause();

            else Play();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        inmenu = true;
    }

    public void Play()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        inmenu = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Settings()
    {

    }

    public void MainMenu()
    {

    }
}
