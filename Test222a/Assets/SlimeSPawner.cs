using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSPawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to be spawned
    public float spawnInterval = 3.0f; // Time between enemy spawns

    void Start()
    {
        // Invoke the SpawnEnemy method every 'spawnInterval' seconds, starting after 0 seconds.
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Instantiate the enemy at the spawner's position
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
