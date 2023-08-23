using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoot
{
    //public GameObject[] SpawnSomeLoot(int lootLevel);
    public void SpawnAnItem(); //this should probably return a GO? Loot manager maybe?
    //public GameObject SpawnRandomLoot();
    public void SpawnGold();//this should probably return a GO? Loot manager maybe?
}
