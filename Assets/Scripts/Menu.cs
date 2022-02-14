using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private SceneChanger sceneChanger;

    private void Awake()
    {
        sceneChanger = new SceneChanger();
    }


    public void StartGame(int buildIndex)
    {
        sceneChanger.LoadScene(buildIndex);
    }
    public void ExitGame()
    {
        sceneChanger.ExitGame();
    }
}
