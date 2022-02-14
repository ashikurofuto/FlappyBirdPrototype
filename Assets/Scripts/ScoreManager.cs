using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager 
{

    public int currentScore { get; private set; }
    public int bestScore { get; private set; }

    public void Init()
    {
        currentScore = 0;
        AddScoreTrigger.onScoreChanged += AddScore;
        LoadBestScore();
    }

    public void AddScore()
    {
        currentScore++;
        
        
    }
    public void CheckBestScore()
    {
        LoadBestScore();
        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            SaveBestScore();
        }
    }
    private void LoadBestScore()
    {
       bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", bestScore);
    }

}
