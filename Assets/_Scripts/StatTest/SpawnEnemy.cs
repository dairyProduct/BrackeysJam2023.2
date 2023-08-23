using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyObject;
    public EnemyBaseSetting enemyStats;
    [SerializeField] float spawnFrequency = 20f; //every 10 seconds
    float spawnTimer = 15f; //give the player a few seconds?
    int spawnCount = 0;
    int maxSpawnCount = 5;

    private void Update()
    {
        if (checkToSpawn())
        {
            Enemy spawn = Instantiate(enemyObject, transform.position, Quaternion.identity).GetComponent<Enemy>();
            spawn.SetStats(enemyStats.entityStats);
            spawnCount++;
        }
    }


    private bool checkToSpawn()
    {
        if(spawnCount >= maxSpawnCount)
        {
            return false;
        }

        if (spawnTimer < spawnFrequency)
        {
            spawnTimer += Time.deltaTime;
            return false;
        }
        else
        {
            spawnTimer = 0f;
            return true;
        }
    }
}
