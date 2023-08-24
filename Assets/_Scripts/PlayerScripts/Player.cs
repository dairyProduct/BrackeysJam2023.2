using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable
{
    protected override void OnDeath()
    {
        Debug.Log("Player died");
        Destroy(gameObject);
    }
}
