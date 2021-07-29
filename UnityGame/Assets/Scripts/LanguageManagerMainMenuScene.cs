using UnityEngine.UI;
using UnityEngine;

public class LanguageManagerMainMenuScene : MonoBehaviour
{
    [SerializeField] private Text Resume, Settings, NewGame, Quit;
    private int language;

    void Start()
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
                Quit.text = "Quit";
                Resume.text = "Resume";
                NewGame.text = "New game";
                Settings.text = "Settings";
                break;

            case 1:
                Quit.text = "Выйти";
                Resume.text = "Продолжить";
                NewGame.text = "Новая игра";
                Settings.text = "Настройки";
                break;

        }
    }
}
