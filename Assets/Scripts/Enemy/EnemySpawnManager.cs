using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public int currentWave;
    public int maxWave;
    public int enemiesInWave;

    public GameObject zombie;
    public float spawnTime = 60f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    // Start is called before the first frame update
    void Start()
    {
        maxWave = 10;
        currentWave = 1;
        enemiesInWave = 3;
        SpawnWave();
        InvokeRepeating("SpawnWave", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWave > 0 && currentWave < 5)
        {
            enemiesInWave = 3;
        }
        if(currentWave >= 5 && currentWave < 10)
        {
            enemiesInWave = 5;
        }
        if(currentWave == 10)
        {
            enemiesInWave = 10;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < enemiesInWave; i++)
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(zombie, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
        currentWave++;
    }
}
