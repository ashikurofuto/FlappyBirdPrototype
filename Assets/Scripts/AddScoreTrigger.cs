using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AddScoreTrigger : MonoBehaviour
{

    public static Action onScoreChanged;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bird>() != null)
        {
            onScoreChanged?.Invoke();
            
            
        }
    }
}
