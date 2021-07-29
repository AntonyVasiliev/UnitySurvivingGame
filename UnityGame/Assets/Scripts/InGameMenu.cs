using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isActive) OpenMenu();

            else CloseMenu();
        }
    }

    public void OpenMenu()
    {
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        isActive = true;
    }

    public void CloseMenu()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isActive = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        isActive = false;
    }

    public bool IsMenuActive()
    {
        return isActive;
    }
}
