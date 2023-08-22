using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyObject;
    public EnemyBaseSetting enemyStats;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Enemy spawn = Instantiate(enemyObject, Vector3.zero, Quaternion.identity).GetComponent<Enemy>();
            spawn.SetStats(enemyStats.entityStats);
        }
    }
}
