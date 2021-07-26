using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Resume()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Game"));
    }

    public void NewGame()
    {

    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
