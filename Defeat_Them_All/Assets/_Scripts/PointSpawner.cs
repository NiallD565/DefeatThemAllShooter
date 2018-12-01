﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Utilities;

public class PointSpawner : MonoBehaviour
{
    private const string DECREASE_SPAWN_INTERVAL = "decrementWavetimer";
    private const string SPAWN_METHOD = "Spawn";
    // timed wave controls
    [SerializeField]
    private float waveTimer = 4.0f;
    [SerializeField]
    private float timeTillWave = 3.0f;

    private bool waveSpawn = false;
    private int spawnedEnemy = 0;
    private float waveSpawnDec = 0.02f;

    private GameObject enemyParent;

    [SerializeField]
    private GameObject enemyPrefab; // type to spawn

    // list for the child SpawnPoints
    //private IList<SpawnPoint> spawnPoints;

    //private Stack<SpawnPoint> spawnStack;


    // Use this for initialization
    void Start()
    {
        // get the list of child object
        //spawnPoints = GetComponentsInChildren<SpawnPoint>();
        //SpawnEnemiesRepeating();
        enemyParent = ParentUtils.FindEnemyParent();
        InvokeRepeating(DECREASE_SPAWN_INTERVAL, 0f, .5f);
    }

    /*private void SpawnEnemiesRepeating()
    {
        // shuffle my stack first (from Utilities namespace)
        //spawnStack = ListUtility.CreateShuffledStack(spawnPoints);
        InvokeRepeating(SPAWN_METHOD, spawnDelay, spawnInterval);
    }
    */
    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, enemyParent.transform.position, transform.rotation);
        enemy.transform.position = transform.position;

        spawnedEnemy++;
        waveSpawn = false;

        //var enemy = Instantiate(enemyPrefab);
        // set the position
        //enemy.transform.position = spawnPoint.transform.position;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
		// Spawns enemies in waves but based on time.
       
        //Debug.Log("Time tll next wave " + timeTillWave);
        // Increases the timer to allow the timed waves to work
        timeTillWave += Time.deltaTime;
            
        // checks if the time is equal to the time required for a new wave
        if (waveTimer <= timeTillWave)
        {
            // enables the wave spawner
            waveSpawn = true;
            // sets the time back to zero
            timeTillWave = 0.0f;
            // increases the number of waves
        }
        if (waveSpawn == true)
        {
            //Debug.Log("Spawnmethod called");
            //spawns an enemy
            SpawnEnemy();
        }

        // caps the spawn interval at a wave every 0.7 second
        if (waveTimer <= 0.7f)
        {
            CancelInvoke(DECREASE_SPAWN_INTERVAL);
        }
    }

    private void decrementWavetimer()
    {
        waveTimer -= waveSpawnDec;
    }
} 
    

