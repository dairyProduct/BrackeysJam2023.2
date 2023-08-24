using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Enemy : Damageable
{
    [SerializeField] Transform target;
    [SerializeField] bool isMelee;
    [SerializeField] bool isRanged;
    [SerializeField] string myName;
    public WeaponAttack myWeapon;
    public TextMeshProUGUI uiName;
    public bool generateName = true;
    float maxDist = 15f; //about camera size - outside of this range don't chase the player
    float meleeRange = 2f;
    bool isInRange = false;

    Rigidbody2D myRb;



    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        getTarget();
        if(uiName != null)
        {
            uiName.text = myName;
        }
        if(generateName)
        {
            myName = NameGenerator.instance.BuildAName();
            uiName.text = myName;
        }
    }

    //TODO - update this to drop loot and be fancy and stuff
    protected override void OnDeath()
    {
        SpawnGold();
        SpawnAnItem(); //Maybe this is on a chance percent? - can even be stat driven
        Destroy(gameObject);
    }

    private void Update()
    {
        getToRange();
        if(isInRange)
        {
            myWeapon.AIAttackCall();
        }
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
        float dist = Vector2.Distance(transform.position, target.position);
        if (dist > meleeRange && dist < maxDist)
        {
            isInRange = false;
            myRb.velocity = (target.position - transform.position).normalized * mystats.speed;
        }
        else if (dist < meleeRange)
        {
            isInRange = true;
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
