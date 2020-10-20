using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnManager : MonoBehaviour
{
    public GameObject health;
    public GameObject mana;
    public GameObject bigBoost;
    GameObject spawnManager;
    EnemySpawnManager enemySpawnManager;
    public int powerupsToSpawn;
    public float spawnTime = 20f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("EnemySpawnManager");
        enemySpawnManager = spawnManager.GetComponent<EnemySpawnManager>();
        powerupsToSpawn = 5;
        SpawnPowerup();
        InvokeRepeating("SpawnPowerup", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemySpawnManager.currentWave == 5)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            //powerup
            Instantiate(bigBoost, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
        if (enemySpawnManager.currentWave == 10)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            //powerup & chance for legendary
            Instantiate(bigBoost, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }

    public void SpawnPowerup()
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            int tossUp = Random.Range(0, 1);
            switch(tossUp)
            {
                case 0:
                    //GameObject health = Resources.Load<GameObject>("Powerup/Health") as GameObject;
                    Instantiate(health, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                    break;
                case 1:
                    Instantiate(mana, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                    break;
            }
            
        }
    }
}
