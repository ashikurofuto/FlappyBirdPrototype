using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty 
{
    private float timer = 0;
    private float spawnTime;

    public float ChangeDifficulty()
    {
        timer += Time.deltaTime;
        if (timer > 15f)
        {
            spawnTime = Random.Range(1.3f, 2.5f);
            if (timer > 30f)
            {
                spawnTime = Random.Range(0.9f, 3f);
            }
            return spawnTime;
        }
        else
        {
            spawnTime = 2.5f;
            return spawnTime;
        }

    }
}
