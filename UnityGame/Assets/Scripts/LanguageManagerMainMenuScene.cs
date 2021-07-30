using UnityEngine.UI;
using UnityEngine;

public class LanguageManagerMainMenuScene : MonoBehaviour
{
    [SerializeField] private Text _resumeText, _settingsText, _newGameText, _quitText;
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
                _quitText.text = "Quit";
                _resumeText.text = "Resume";
                _newGameText.text = "New game";
                _settingsText.text = "Settings";
                break;

            case 1:
                _quitText.text = "Выйти";
                _resumeText.text = "Продолжить";
                _newGameText.text = "Новая игра";
                _settingsText.text = "Настройки";
                break;

        }
    }
}
