using UnityEngine.UI;
using UnityEngine;

public class LanguageManagerGameScene : MonoBehaviour
{
    public Text Resume, Settings, MainMenu, Exit;
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
                Exit.text = "Exit";
                Resume.text = "Resume";
                MainMenu.text = "Main menu";
                Settings.text = "Settings";
                break;

            case 1:
                Exit.text = "Выйти";
                Resume.text = "Продолжить";
                MainMenu.text = "Главное меню";
                Settings.text = "Настройки";
                break;

        }
    }
}
