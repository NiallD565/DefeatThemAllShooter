using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using Utilities;

public class PointSpawner : MonoBehaviour
{

    private const string SPAWN_METHOD = "Spawn";
    // timed wave controls
    [SerializeField]
    private float waveTimer = 4.0f;
    [SerializeField]
    private float timeTillWave = 3.0f;
    [SerializeField]
    private int totalWaves = 15;

    private int numWaves = 0;
    private bool waveSpawn = false;
    private int numEnemy = 0;
    private int spawnedEnemy = 0;

    private GameObject enemyParent;


    [SerializeField]
    private float spawnDelay = 0.5f;
    [SerializeField]
    private float spawnInterval = 0.5f;
    [SerializeField]
    private GameObject enemyPrefab; // type to spawn
    //private Enemy enemyPrefab;

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
        // take spawn point from stack
        // if the stack is empty, then reshuffle 

        // reshuffle
        //spawnStack = ListUtility.CreateShuffledStack(spawnPoints);


        //var spawnPoint = spawnStack.Pop();
        GameObject enemy = Instantiate(enemyPrefab, enemyParent.transform.position, transform.rotation);
        enemy.transform.position = transform.position;
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        //rb.velocity = Vector3.down;

        numEnemy++;
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
        // checks if the number of waves is bigger than the total waves
        if (numWaves <= totalWaves)
        {
            Debug.Log("Time tll next wave " + timeTillWave);
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
                numWaves++;
                // A hack to get it to spawn the same number of enemies regardless of how many have been killed
                numEnemy = 0;
            }
            if (waveSpawn == true)
            {
                Debug.Log("Spawnmethod called");
                //spawns an enemy
                SpawnEnemy();
            }
        }
    }
} 
    

