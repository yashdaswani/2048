using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text HighScore;

    private void Start()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
        
        Hscore();

    }

    public void Hscore()
    {
        HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }




}
