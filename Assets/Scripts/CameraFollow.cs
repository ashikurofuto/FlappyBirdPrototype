using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smooth;


    private void Update()
    {
        CameraPos();
    }

    private void CameraPos()
    {
        float posX = Mathf.Lerp(transform.position.x, player.position.x, smooth * Time.deltaTime);
        transform.position = new Vector3(posX, 0f, -10f);
    }
}
