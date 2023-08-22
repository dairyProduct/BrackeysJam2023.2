using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Enemy : Damageable
{
    [SerializeField] Transform target;
    [SerializeField] bool isMelee;
    [SerializeField] bool isRanged;
    Rigidbody2D myRb;



    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        getTarget();
    }

    //TODO - update this to drop loot and be fancy and stuff
    protected override void OnDeath()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        getToRange();
    }


    void getToRange()
    {
        if (isMelee)
        {
            goToMeleeRange();
        }
        if (isRanged)
        {
            goToRangedRange();
        }
    }


    void goToMeleeRange()
    {
        if (Vector2.Distance(transform.position, target.position) > mystats.meleeReach)
        {
            myRb.velocity = target.position - transform.position * mystats.speed;
        }
    }

    void goToRangedRange()
    {
        //TODO
    }

    void getTarget()
    {
        target = GameObject.FindWithTag("Player").transform;
    }


}
