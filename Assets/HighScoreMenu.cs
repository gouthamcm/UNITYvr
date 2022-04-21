using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreMenu : MonoBehaviour
{
    public Text Scores;
    private string top_scores = "";
    private string[] KEYS = {"H1", "H2", "H3", "H4", "H5", "H6", "H7", "H8", "H9", "H10"}; 
    
    

    void Start()
    {
        
    }

    void Update()
    {
        for(int i=0; i<KEYS.Length; i++)
        {
            top_scores += PlayerPrefs.GetInt(KEYS[i]).ToString() + "\n";

        }
        // top_scores += PlayerPrefs.GetInt(KEYS[KEYS.Length-1]).ToString();

        Scores.text = top_scores;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
