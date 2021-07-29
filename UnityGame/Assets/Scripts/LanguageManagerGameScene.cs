using UnityEngine.UI;
using UnityEngine;

public class LanguageManagerGameScene : MonoBehaviour
{
    [SerializeField] private Text Resume, Settings, MainMenu, Exit;
    private int language;

    private void Start()
    {
        // Get language
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
