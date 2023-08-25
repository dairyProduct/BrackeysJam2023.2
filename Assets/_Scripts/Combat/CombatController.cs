using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public ContactFilter2D contactFilter2D;

    public Item currentWeapon;
    bool attacking;
    public BoxCollider2D hitbox;

    public Animator animator;
    
    Collider2D[] overlaps = new Collider2D[20];

    private void Start() {
        
    }
    public void SetWeapon(Item item) {
        currentWeapon = item;
    }

    public void ShootProjectile() {

    }

    public void Attack() {
        StartCoroutine(LightAttack());
    }

    public IEnumerator LightAttack() {
        attacking = true;
        animator.SetTrigger("Light");
        Array.Clear(overlaps, 0, overlaps.Length);
        hitbox.OverlapCollider(contactFilter2D, overlaps);
        for (int i = 0; i < overlaps.Length; i++)
        {
            if(overlaps[i] == null) continue;
            IDamageable other;
            if(overlaps[i].gameObject.TryGetComponent<IDamageable>(out other)) {
                other.Damage(currentWeapon.damage);
            }
        }
        yield return new WaitForSeconds(.1f);
        attacking = true;
    }
    public IEnumerator HeavyAttack() {
        attacking = true;
        yield return new WaitForSeconds(0);
    }
}
