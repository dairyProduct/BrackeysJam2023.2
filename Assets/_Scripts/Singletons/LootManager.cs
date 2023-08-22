using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour
{
    public static LootManager instance;
    //GameObject loot table or lookup
    public GameObject smallGold;
    public GameObject mediumGold;
    public GameObject largeGold;
    public GameObject testLoot;
    public int goldLevelMultiplier = 5;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SpawnLoot(Vector2 position, int lootLevel)
    {
        Instantiate(testLoot, position, Quaternion.identity);
    }

    public void SpawnGold(Vector2 position, int amount)
    {
        amount = amount * goldLevelMultiplier;
        if(amount <= 25)
        {
            Instantiate(smallGold, position, Quaternion.identity);
        }
        if(amount > 25 && amount <= 50)
        {
            Instantiate(mediumGold, position, Quaternion.identity);
        }
        if(amount > 50 && amount <= 100)
        {
            Instantiate(largeGold, position, Quaternion.identity);
        }
        if(amount > 100)
        {
            Instantiate(largeGold, position + Vector2.up, Quaternion.identity);
            Instantiate(largeGold, position + Vector2.down, Quaternion.identity);
        }
    }


}
