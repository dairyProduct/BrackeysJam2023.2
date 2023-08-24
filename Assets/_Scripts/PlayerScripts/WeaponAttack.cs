using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public GameObject equippedWeapon;
    public GameObject backupWeapon;
    public Weapon weaponScript;
    public float attackReload =0;
    public bool isAttacking = false;
    public Transform weaponPoint;
    public Transform swordHold;
    public Transform spearHold;
    public Transform weaponLocation;
    public bool isAI;
    bool aiAttack;

    private void Start()
    {
        updateWeaponData();
        weaponScript.owner = gameObject.transform;
    }

    private void Update()
    {
        if(checkForInput() && canAttack())
        {
            Debug.Log("SlicenDice!");
            attack();
        }
        if(isAttacking)
        {
            //nothing
        }
        if(!isAttacking)
        {
            checkForSwap();
            weaponLocation.position = weaponPoint.position;
            weaponLocation.rotation = weaponPoint.rotation;
        }

        updateTimer();
    }


    public void AIAttackCall()
    {
        aiAttack = true;
    }

    bool checkForInput()
    {
        if(isAI)
        {
            if(aiAttack)
            {
                return true;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }

    void checkForSwap()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Swapped Weapons!");
            GameObject temp = equippedWeapon;
            equippedWeapon.SetActive(false);
            equippedWeapon = backupWeapon;
            equippedWeapon.SetActive(true);
            backupWeapon = temp;
            updateWeaponData();
        }

    }

    void updateWeaponData()
    {
        if (equippedWeapon != null)
        {
            weaponScript = equippedWeapon.GetComponent<Weapon>();
            weaponScript.owner = gameObject.transform;
            if (weaponPoint == spearHold)
            {
                weaponPoint = swordHold;
            }
            else
            {
                weaponPoint = spearHold;
            }
            weaponLocation = equippedWeapon.transform;
        }
    }

    bool canAttack()
    {
        if(!isAttacking)
        {
            return true;
        }
        if(isAttacking)
        {
            return false;
        }
        return false;
    }

    void updateTimer()
    {
        if(isAttacking)
        {
            attackReload += Time.deltaTime;
            if(attackReload > weaponScript.speed)
            {
                isAttacking = false;
                attackReload = 0f;
                weaponScript.isAttacking = false;
                aiAttack = false;
            }
        }
        else
        {
            //equippedWeapon.gameObject.SetActive(false);
            //Do nothing
        }
    }

    void attack()
    {
        isAttacking=true;
        equippedWeapon.gameObject.SetActive(true);
        weaponScript.isAttacking = true;
    }

  


}
