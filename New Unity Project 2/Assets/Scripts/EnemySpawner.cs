using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnDelay, removalDelay;      // Time inbetween spawns, time before dead bodies are removed
    public float spawnRadius;                   // Radius from spawnPoint that the enemy can spawn in
    public int initPoolCount;                   // Initial amount of enemies to be spawned
    public int totEnemies;                      // Total enemies to be spawned before the stop spawning
    public int concurrentEnemies;               // Amount of enemies that can be on the same screen at once
    private int enemiesSpawned;                 // Total enemies spawned so far
    public int enemiesKilled;                   // Total enemies killed so far
    private bool allSpawned;                    // If all the enemies have been spawned

    private Vector2 spawnPoint, relativePos;    // Where to spawn the enemies, where the enemy should be looking
    public Transform target;                    // The player's position
    private Quaternion rotation;                // The enemy's rotation
    
    void Start()
    {
        enemiesSpawned = 0;
        enemiesKilled = 0;
        allSpawned = false;
        for (int i = 0; i < initPoolCount; i++)
        {
            Spawn();
            //Make this wait for spawnDelay seconds per repeat
        }
    }
    
    void Update()
    {
        relativePos = target.position - transform.position;

        // Looks at player
        rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        if(!allSpawned)
        {
            if (enemiesSpawned < totEnemies)
            {
                if (enemiesSpawned - enemiesKilled < concurrentEnemies)
                {
                    Spawn();
                }
            }
            else
            {
                allSpawned = true;
                //Debug.Log("All Spawned");
            }
        }
    }

    void Spawn()
    {
        spawnPoint = new Vector2(transform.position.x + spawnRadius * Random.Range(-1.0f,1.0f), 
                                 transform.position.y + spawnRadius * Random.Range(-1.0f, 1.0f));
        Instantiate(prefab, spawnPoint, rotation);
        enemiesSpawned++;
    }
}