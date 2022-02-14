using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMustDie : MonoBehaviour
{

    [SerializeField] private Image diePanel;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text highScore;
    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = new ScoreManager();
    }

    private void OnEnable()
    {
        Bird.OnDie += Die;
    }
    private void OnDisable()
    {
        Bird.OnDie -= Die;
    }

    private void Die()
    {
        diePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        scoreManager.CheckBestScore();
        currentScore.text = $"Currnet score : {scoreManager.currentScore}";
        highScore.text = $"Best Score : {scoreManager.bestScore}";
    }
}
