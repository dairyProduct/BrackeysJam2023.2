using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Weapon : MonoBehaviour
{
    public float arc = 180f;
    public float speed = .7f;
    public Transform owner;
    public int damage;
    public bool isAttacking = false;
    public bool hasDamaged = false;
    public BoxCollider2D damageBox;

    private void Start()
    {
    }

    private void Update()
    {
        if (!isAttacking)
        {
            damageBox.enabled = false;
            hasDamaged = false;
            //transform.position = owner.position + owner.forward + offset;
        }
        if(isAttacking)
        {
            damageBox.enabled = true;
            Attack();
        }
    }

    public void Attack()
    {
        transform.RotateAround(owner.position, Vector3.back, arc*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasDamaged)
        {
            Debug.Log("Weapon smacked something! " + collision.gameObject.tag);
            if (collision.gameObject.TryGetComponent(out Damageable damageable))
            {
                damageable.TakeDamage(damage);
                hasDamaged = true;
            }
        }
    }
}
