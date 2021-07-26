using UnityEngine;
using UnityEngine.UI;


public class LanguageManagerSettingsScene : MonoBehaviour
{
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
                Volume.text = "Volume";
                Save.text = "Save";
                Exit.text = "Exit";
                Language.text = "Language";
                Graphics.text = "Graphics";
                FullScreen.text = "Full Screen";
                break;

            case 1:
                Volume.text = "Громкость";
                Save.text = "Сохранить";
                Exit.text = "Выйти";
                Language.text = "Язык";
                Graphics.text = "Видео";
                FullScreen.text = "Полный экран";
                break;

        }
    }
}
