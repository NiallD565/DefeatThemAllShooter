using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string CIRCLE_TAG_TEXT = "Circle";

    [SerializeField]
    private int scoreValue = 10;

    [SerializeField]
    private AudioClip hitClip;

    [SerializeField]
    private AudioClip crashClip;

    private SoundController soundController;

    // create public property
    public int ScoreValue { get { return scoreValue; } }

    // EnemyKilledEvent handlers
    public delegate void EnemyKilled(Enemy enemy);

    // static event
    public static EnemyKilled EnemyKilledEvent;

    // == private methods ==
    private void Start()
    {
        soundController = SoundController.FindSoundController();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // need to determine the type of "collision"
        string tagType = gameObject.tag;
        //var bullet = collision.GetComponent<Bullet>();
        //var player = collision.GetComponent<PlayerBehaviour>();

        if(collision.gameObject.tag =="bullet")
        {
            PlayClip(hitClip);
            GameObject.Destroy(gameObject);
            PublishEnemyKilledEvent();
            //Destroy(gameObject);
        }
        
    }

    private void PlayClip(AudioClip clip)
    {
        if (soundController)
        {
            soundController.PlayOneShot(clip);
        }
    }

    private void PublishEnemyKilledEvent()
    {
        if (EnemyKilledEvent != null)
        {
            EnemyKilledEvent(this);
        }

    }
}
