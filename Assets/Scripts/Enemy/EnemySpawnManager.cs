using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnManager : MonoBehaviour
{
    public int currentWave;
    public int maxWave;
    public int enemiesInWave;

    public GameObject zombie;
    public float spawnTime = 30f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    GameObject[] enemies;
    public Text waveCount;

    // Start is called before the first frame update
    void Start()
    {
        maxWave = 5;
        currentWave = 0;
        enemiesInWave = 3;
        waveCount.text = "0";
        SpawnWave();
        InvokeRepeating("SpawnWave", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWave > 0 && currentWave < 3)
        {
            enemiesInWave = 3;
        }
        if(currentWave >= 3 && currentWave < 5)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyAttack>().attackDamage = 20;
            }
            enemiesInWave = 5;
        }
        if(currentWave == 5)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyAttack>().attackDamage = 25;
            }
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
        waveCount.text = currentWave.ToString();
    }
}
