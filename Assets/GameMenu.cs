using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void onGameLoad()
    {
        SceneManager.LoadScene(2);
    }

    public void HighScoreMenu()
    {
        SceneManager.LoadScene(1);
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }
}
