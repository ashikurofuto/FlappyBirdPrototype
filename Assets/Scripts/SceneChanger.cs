using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger 
{
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public void RestartScene()
    {
        string currentName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
