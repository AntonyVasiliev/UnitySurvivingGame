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
    private float Mainvolume = 0;
    private int GraphicsQuality = 5;
    private bool IsFullScreen;
    Resolution resolution;
    Resolution[] resolutions;

    private void Start()
    {
        //Load saved settings
        volumeSlider.value = Mainvolume;
        graphicsDropdown.value = GraphicsQuality;

        //Get user resolution
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
            options.Add(resolutions[i].width + " x " + resolutions[i].height);

        resolutionDropdown.AddOptions(options);
    }

    public void Save()
    {
        audioMixer.SetFloat("Volume", Mainvolume);

        QualitySettings.SetQualityLevel(GraphicsQuality);

        Screen.fullScreen = IsFullScreen;

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
        Mainvolume = volume;
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
        resolution = resolutions[resolutionIndex];
        Debug.Log(resolution.width + " x " + resolution.height);
    }

}
