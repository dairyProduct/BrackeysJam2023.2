using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Enemy : Damageable
{

    //TODO - update this to drop loot and be fancy and stuff
    protected override void OnDeath()
    {
        Destroy(gameObject);
    }

}
