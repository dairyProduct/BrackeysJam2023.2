using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public BoxCollider2D damageBox;
    public SpriteRenderer attackSprite;
    public float attackTime = .6f; //attacks "linger" for ~half a second
    public float currentTimer = 0f;
    public bool isAttacking = false;
    public int damage = 3; //Need to get or calc this from stats?
    public float earlyCleanupTimer = .3f; //time to react/register something is about .3 seconds
    public bool isEarlyCleanup = false;

    private void Start()
    {
        damageBox.enabled = false;
        attackSprite.enabled = false;
    }

    private void Update()
    {
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0) && !isAttacking)
        {
            DrawAttack();
        }

        if(isAttacking)
        {
            currentTimer += Time.deltaTime;
        }

        if(currentTimer > attackTime)
        {
            CleanUpAttack();
        }
        if(isEarlyCleanup && currentTimer > earlyCleanupTimer)
        {
            CleanUpAttack();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Player smacked something! " + collision.gameObject.tag);
        if (collision.gameObject.TryGetComponent(out Damageable damageable))
        {
            damageable.TakeDamage(damage);
            OnHitCleanUpAttack();
        }
    }


    void DrawAttack()
    {
        attackSprite.enabled = true;
        damageBox.enabled = true;
        isAttacking = true;
    }

    void CleanUpAttack()
    {
        attackSprite.enabled = false;
        damageBox.enabled = false;
        isAttacking = false;
        currentTimer = 0f;
    }

    void OnHitCleanUpAttack() //This intentionally leaves us "isAttacking" since we don't want to double hit, but want to reset faster
    {
        attackSprite.enabled = false;
        damageBox.enabled = false;
        isEarlyCleanup = true;
    }
}
