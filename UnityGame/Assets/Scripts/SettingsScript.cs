using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [SerializeField] private GameObject _settings, _pauseMenu, _reloadText;
    [SerializeField] private Dropdown _graphicsDropdown, _resolutionDropdown, _languageDropdown;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioMixer _audioMixer;
    private float _mainVolume;
    private int _graphicsQuality, _resolutionIndex, _languageIndex;
    private bool _isFullScreen, _isReload;
    private Resolution _resolution;
    private Resolution[] _resolutions;

    private void Start()
    {
        HideReload();

        GetResolution();

        LoadSettings();
    }

    private void GetResolution()
    {
        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < _resolutions.Length; i++)
            options.Add(_resolutions[i].width + " x " + _resolutions[i].height);

        _resolutionDropdown.AddOptions(options);
    }

    private void LoadSettings()
    {
        _mainVolume = PlayerPrefs.GetFloat("MainVolume");
        _graphicsQuality = PlayerPrefs.GetInt("GraphicsQuality");
        _isFullScreen = PlayerPrefs.GetInt("IsFullScreen") == 1 ? true : false;
        _resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
        _languageIndex = PlayerPrefs.GetInt("LanguageIndex");

        _volumeSlider.value = _mainVolume;
        _graphicsDropdown.value = _graphicsQuality;
        _resolutionDropdown.value = _resolutionIndex;
        _languageDropdown.value = _languageIndex;
    }

    private void NotifyReload()
    {
        _isReload = true;
        _reloadText.SetActive(true);
    }

    private void HideReload()
    {
        _isReload = false;
        _reloadText.SetActive(false);
    }

    public void Save()
    {
        //save settings
        PlayerPrefs.SetFloat("MainVolume", _mainVolume);
        _audioMixer.SetFloat("Volume", _mainVolume);

        PlayerPrefs.SetInt("GraphicsQuality", _graphicsQuality);
        QualitySettings.SetQualityLevel(_graphicsQuality);

        PlayerPrefs.SetInt("IsFullScreen", _isFullScreen ? 1 : 0);
        Screen.fullScreen = _isFullScreen;

        PlayerPrefs.SetInt("ResolutionIndex", _resolutionIndex);
        Screen.SetResolution(_resolution.width, _resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("LanguageIndex", _languageIndex);

        //Reload
        if (_isReload)
        {
            _isReload = false;
            _reloadText.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Exit()
    {
        HideReload();

        _settings.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    //Audio Settings
    public void SetVolume(float volume)
    {
        _mainVolume = volume;
    }

    //Graphics Settings
    public void SetQuality(int quality)
    {
        _graphicsQuality = quality;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        _isFullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        _resolutionIndex = resolutionIndex;
        _resolution = _resolutions[resolutionIndex];
    }

    //Game settings
    public void SetLanguage(int languageIndex)
    {
        if (languageIndex != PlayerPrefs.GetInt("LanguageIndex")) NotifyReload();
        else HideReload();

        _languageIndex = languageIndex;
    }
}
