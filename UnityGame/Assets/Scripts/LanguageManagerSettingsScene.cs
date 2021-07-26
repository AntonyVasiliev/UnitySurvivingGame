using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LanguageManagerSettingsScene : MonoBehaviour
{
    public Dropdown qualityDropdown;
    public Text Volume, Save, Exit, Language, Graphics, FullScreen;
    private int language;

    void Start()
    {
        // Get language
        if (!PlayerPrefs.HasKey("languageInd")) PlayerPrefs.SetInt("languageInd", 0);
        language = PlayerPrefs.GetInt("languageInd");

        ChangeLanguage();
    }

    public void ChangeLanguage()
    {
        switch (language)
        {
            case 0:
                {
                    Volume.text = "Volume";
                    Save.text = "Save";
                    Exit.text = "Exit";
                    Language.text = "Language";
                    Graphics.text = "Graphics";
                    FullScreen.text = "Full Screen";

                    //Dropdown
                    List<string> options = new List<string>(new string[] {"Very low",
                    "Low", "Medium", "High", "Very high", "Ultra" });
                    qualityDropdown.AddOptions(options);
                }
                break;

            case 1:
                {
                    Volume.text = "Громкость";
                    Save.text = "Сохранить";
                    Exit.text = "Выйти";
                    Language.text = "Язык";
                    Graphics.text = "Видео";
                    FullScreen.text = "Полный экран";
                    //Dropdown
                    List<string> options = new List<string>(new string[] {"Жмыхнуло",
                    "Второе пришествие", "Среднячок", "Класс", "Супер", "Супер класс" });
                    qualityDropdown.AddOptions(options);
                }
                break;

        }
    }
}
