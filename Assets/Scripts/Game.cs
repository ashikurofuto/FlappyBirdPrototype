using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Text scoreHood;
    [SerializeField] private Text highScore;
    [SerializeField] private ColoumnSpanwer spanwer;
    private ScoreManager scoreManager;
    private SceneChanger sceneChanger;


    private void Awake()
    {
        scoreManager = new ScoreManager();
        sceneChanger = new SceneChanger();
        scoreManager.Init();
        SetScoreHood();
        PlayTime();
    }
    private void OnEnable()
    {
        AddScoreTrigger.onScoreChanged += SetScoreHood;
    }
    private void OnDisable()
    {
        AddScoreTrigger.onScoreChanged -= SetScoreHood;
    }


    public void StopTime()
    {
        Time.timeScale = 0; 
    }
    public void PlayTime()
    {
        Time.timeScale = 1;
    }


    private void SetScoreHood()
    {
        scoreHood.text = $"Score : {scoreManager.currentScore}";
        
    }
    public void CheckHighScore()
    {
        scoreManager.CheckBestScore();
        highScore.text = $"Your Best Score : {scoreManager.bestScore}";
    }

    public void LoadScene(int buildIndex)
    {
        sceneChanger.LoadScene(buildIndex);
    }
    public void Restart()
    {
        sceneChanger.RestartScene();
    }

}
