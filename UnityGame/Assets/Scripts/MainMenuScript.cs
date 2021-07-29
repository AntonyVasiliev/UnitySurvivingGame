using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void Start()
    {
        CreatePlayerPref("languageInd", 0);
        CreatePlayerPref("mainVolume", 0);
        CreatePlayerPref("GraphicsQuality", 5);
        CreatePlayerPref("IsFullScreen", 1);
        CreatePlayerPref("resolutionInd", 0);
        CreatePlayerPref("languageInd", 0);

        LoadSettings();
    }

    public void Resume()
    {
        SceneManager.LoadScene("GameScene");
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

    private void CreatePlayerPref(string pref, int value)
    {
        if (!PlayerPrefs.HasKey(pref)) PlayerPrefs.SetFloat(pref, value);
    }

    private void LoadSettings()
    {
        float mainVolume = PlayerPrefs.GetFloat("mainVolume");
        audioMixer.SetFloat("Volume", mainVolume);

        int GraphicsQuality = PlayerPrefs.GetInt("GraphicsQuality");
        QualitySettings.SetQualityLevel(GraphicsQuality);

        bool IsFullScreen = PlayerPrefs.GetInt("IsFullScreen") == 1 ? true : false;
        Screen.fullScreen = IsFullScreen;

        int resolutionInd = PlayerPrefs.GetInt("resolutionInd");

        Resolution[] resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
            options.Add(resolutions[i].width + " x " + resolutions[i].height);
        Resolution resolution = resolutions[resolutionInd];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
