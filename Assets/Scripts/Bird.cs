using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public static Action OnDie;

    [Header("Physics")]
    [SerializeField] private float jumpForce;
    [Header("Sound")]
    [SerializeField] private AudioClip wingSound;
    private BirdWing wing;
    private Rigidbody2D rigid;
    private AudioSource audio;



    private void Awake()
    {
        wing = new BirdWing();
        rigid = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            wing.WingAcceleration(rigid, jumpForce);
            BirdAudio();
        }
    }



    private void BirdAudio()
    {
        audio.Stop();
        audio.clip = wingSound;
        audio.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Obstacles>() != null)
        {
            OnDie?.Invoke();
        }
    }

}
