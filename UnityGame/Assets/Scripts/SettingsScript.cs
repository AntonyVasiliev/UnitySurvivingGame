using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Dropdown graphicsDropdown, resolutionDropdown;
    public Slider volumeSlider;
    public AudioMixer audioMixer;
    private float mainVolume;
    private int GraphicsQuality, resolutionInd;
    private bool IsFullScreen;
    Resolution resolution;
    Resolution[] resolutions;

    private void Start()
    {
        //Get user resolution

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
            options.Add(resolutions[i].width + " x " + resolutions[i].height);

        resolutionDropdown.AddOptions(options);



        //Creating PlayerPrefs

        if (!PlayerPrefs.HasKey("mainVolume")) PlayerPrefs.SetFloat("mainVolume", 0);

        if (!PlayerPrefs.HasKey("GraphicsQuality")) PlayerPrefs.SetInt("GraphicsQuality", 5);

        if (!PlayerPrefs.HasKey("IsFullScreen")) PlayerPrefs.SetInt("IsFullScreen", 1);

        if (!PlayerPrefs.HasKey("resolutionInd")) PlayerPrefs.SetInt("resolutionInd", 0);


        //Load saved settings

        mainVolume = PlayerPrefs.GetFloat("mainVolume");
        GraphicsQuality = PlayerPrefs.GetInt("GraphicsQuality");
        IsFullScreen = PlayerPrefs.GetInt("IsFullScreen") == 1 ? true : false;
        resolutionInd = PlayerPrefs.GetInt("resolutionInd");



        volumeSlider.value = mainVolume;
        graphicsDropdown.value = GraphicsQuality;
        resolutionDropdown.value = resolutionInd;
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
    }

    public void Exit()
    {
        if (InGameMenu.inmenu) SceneManager.LoadScene("GameScene");
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

}
