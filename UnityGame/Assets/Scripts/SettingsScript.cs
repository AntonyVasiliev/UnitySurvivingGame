using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SettingsScript : MonoBehaviour
{
    public void Save()
    {
        
    }

    public void Exit()
    {
        if (InGameMenu.inmenu) SceneManager.LoadScene("GameScene");
        else SceneManager.LoadScene("MainMenu");
    }
}
