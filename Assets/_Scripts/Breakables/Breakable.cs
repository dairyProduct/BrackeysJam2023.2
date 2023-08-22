using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Breakable : Damageable
{

    /*protected override void OnDeath()
    {
        Destroy(gameObject);
    }*/

    protected abstract void OnBreak();
    

}
