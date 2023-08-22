using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Breakable
{

    public GameObject replaceWithRubble;
    [SerializeField] bool spawnsLoot;

    protected override void OnBreak()
    {
        if(spawnsLoot)
        {
            SpawnAnItem();
            SpawnGold();
        }
        Instantiate(replaceWithRubble, transform.position, Quaternion.identity);
    }

    protected override void OnDeath()
    {
        OnBreak();
        Destroy(gameObject);
    }


}
