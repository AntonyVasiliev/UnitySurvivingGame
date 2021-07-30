using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _pauseMenu;
    private bool _isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isActive) OpenMenu();

            else CloseMenu();
        }
    }

    public void OpenMenu()
    {
        _pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        _isActive = true;
    }

    public void CloseMenu()
    {
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        _isActive = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        _settings.SetActive(true);
        _pauseMenu.SetActive(false);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        _isActive = false;
    }

    public bool IsMenuActive()
    {
        return _isActive;
    }
}
