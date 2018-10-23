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
        PlayClip(spawnClip);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // need to determine the type of "collision"
        string tagType = gameObject.tag;
        var bullet = collision.GetComponent<Bullet>();
        var player = collision.GetComponent<PlayerBehaviour>();

        if(bullet && (tagType == CIRCLE_TAG_TEXT))
        {
            PlayClip(hitClip);
            Destroy(bullet.gameObject);
            PublishEnemyKilledEvent();
            Destroy(gameObject);
        }
        else if (player)
        {
            PlayClip(crashClip);
            // publish event to the system to notify of hit.
            PublishEnemyKilledEvent();
            // destory the current gameObject
            Destroy(gameObject);

        }
        else
        {
            Debug.Log("hit something else");
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
