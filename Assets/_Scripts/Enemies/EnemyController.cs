using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public CombatController combatController;

    public void Damage(float damage) {
        Destroy(gameObject);
    }
}
