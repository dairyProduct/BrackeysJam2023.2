using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class Damageable : MonoBehaviour, ILoot
{
    [SerializeField] protected StatBlock mystats;
    public void SetStats(StatBlock stats)
    {
        mystats.CopyStatBlock(stats);
        transform.localScale = transform.localScale * mystats.sizeScaler;
    }

    public void TakeDamage(int amount)
    {
        mystats.health -= amount;
        checkForDeath();
    }


    void checkForDeath()
    {
        if(mystats.health < 0)
        {
            OnDeath();
        }
    }

    abstract protected void OnDeath(); //Force the children to implement this - that way each Damageable handles death correctly

    public void SpawnAnItem()
    {
        LootManager.instance.SpawnLoot(transform.position, mystats.level);
    }

    public void SpawnGold()
    {
        LootManager.instance.SpawnGold(transform.position, mystats.level);
    }
}
