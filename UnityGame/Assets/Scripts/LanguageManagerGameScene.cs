using UnityEngine.UI;
using UnityEngine;

public class LanguageManagerGameScene : MonoBehaviour
{
    [SerializeField] private Text _resumeText, _settingsText, _mainMenu, _exitText;
    private int _language;

    private void Awake()
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
                _exitText.text = "Exit";
                _resumeText.text = "Resume";
                _mainMenu.text = "Main menu";
                _settingsText.text = "Settings";
                break;

            case 1:
                _exitText.text = "Выйти";
                _resumeText.text = "Продолжить";
                _mainMenu.text = "Главное меню";
                _settingsText.text = "Настройки";
                break;

        }
    }
}
