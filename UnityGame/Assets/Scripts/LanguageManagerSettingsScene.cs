using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LanguageManagerSettingsScene : MonoBehaviour
{
    [SerializeField] private Dropdown _qualityDropdown;
    [SerializeField] private Text _volumeText, _saveText, _exitText, _languageText, _graphicsText, _fullScreenText;
    private int _language;

    void Awake()
    {
        // Get language
        _language = PlayerPrefs.GetInt("LanguageIndex");

        ChangeLanguage();
    }

    public void ChangeLanguage()
    {
        switch (_language)
        {
            case 0:
                {
                    _volumeText.text = "Volume";
                    _saveText.text = "Save";
                    _exitText.text = "Exit";
                    _languageText.text = "Language";
                    _graphicsText.text = "Graphics";
                    _fullScreenText.text = "Full Screen";

                    //Dropdown
                    List<string> options = new List<string>(new string[] {"Very low",
                    "Low", "Medium", "High", "Very high", "Ultra" });
                    _qualityDropdown.AddOptions(options);
                }
                break;

            case 1:
                {
                    _volumeText.text = "Громкость";
                    _saveText.text = "Сохранить";
                    _exitText.text = "Выйти";
                    _languageText.text = "Язык";
                    _graphicsText.text = "Видео";
                    _fullScreenText.text = "Полный экран";

                    //Dropdown
                    List<string> options = new List<string>(new string[] {"Жмыхнуло",
                    "Второе пришествие", "Среднячок", "Класс", "Супер", "Супер класс" });
                    _qualityDropdown.AddOptions(options);
                }
                break;

        }
    }
}
