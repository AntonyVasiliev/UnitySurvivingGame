using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void Start()
    {
        //Creating PlayerPrefs

        if (!PlayerPrefs.HasKey("mainVolume")) PlayerPrefs.SetFloat("mainVolume", 0);

        if (!PlayerPrefs.HasKey("GraphicsQuality")) PlayerPrefs.SetInt("GraphicsQuality", 5);

        if (!PlayerPrefs.HasKey("IsFullScreen")) PlayerPrefs.SetInt("IsFullScreen", 1);

        if (!PlayerPrefs.HasKey("resolutionInd")) PlayerPrefs.SetInt("resolutionInd", 0);

        if (!PlayerPrefs.HasKey("languageInd")) PlayerPrefs.SetInt("languageInd", 0);



        //Load saved settings

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
}
