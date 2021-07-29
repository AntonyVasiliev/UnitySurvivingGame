using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] private Dropdown graphicsDropdown, resolutionDropdown, languageDropdown;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;
    private float mainVolume;
    private int GraphicsQuality, resolutionInd, languageInd;
    private bool IsFullScreen;
    private Resolution resolution;
    private Resolution[] resolutions;

    private void Start()
    {
        GetResolution();

        LoadSettings();
    }

    private void GetResolution()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
            options.Add(resolutions[i].width + " x " + resolutions[i].height);

        resolutionDropdown.AddOptions(options);
    }

    private void LoadSettings()
    {
        mainVolume = PlayerPrefs.GetFloat("mainVolume");
        GraphicsQuality = PlayerPrefs.GetInt("GraphicsQuality");
        IsFullScreen = PlayerPrefs.GetInt("IsFullScreen") == 1 ? true : false;
        resolutionInd = PlayerPrefs.GetInt("resolutionInd");
        languageInd = PlayerPrefs.GetInt("languageInd");

        volumeSlider.value = mainVolume;
        graphicsDropdown.value = GraphicsQuality;
        resolutionDropdown.value = resolutionInd;
        languageDropdown.value = languageInd;
    }


    public void Save()
    {
        PlayerPrefs.SetFloat("mainVolume", mainVolume);
        audioMixer.SetFloat("Volume", mainVolume);

        PlayerPrefs.SetInt("GraphicsQuality", GraphicsQuality);
        QualitySettings.SetQualityLevel(GraphicsQuality);

        PlayerPrefs.SetInt("IsFullScreen", IsFullScreen ? 1 : 0);
        Screen.fullScreen = IsFullScreen;

        PlayerPrefs.SetInt("resolutionInd", resolutionInd);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("languageInd", languageInd);
    }

    public void Exit()
    {
        if (true) SceneManager.LoadScene("GameScene");
        else SceneManager.LoadScene("MainMenu");
    }

    //Audio Settings
    public void SetVolume(float volume)
    {
        mainVolume = volume;
    }

    //Graphics Settings
    public void SetQuality(int quality)
    {
        GraphicsQuality = quality;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        IsFullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        resolutionInd = resolutionIndex;
        resolution = resolutions[resolutionIndex];
    }

    //Game settings
    public void SetLanguage(int languageIndex)
    {
        languageInd = languageIndex;
    }
}
