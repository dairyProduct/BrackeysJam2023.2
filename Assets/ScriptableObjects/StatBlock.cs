using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatBlock
{
    //string name? - Combat log

    public int health;
    public int stamina;
    public int magic;
    public float sizeScaler;


    public void CopyStatBlock(StatBlock newStats)
    {
        this.health = newStats.health;
        this.stamina = newStats.stamina;
        this.magic = newStats.magic;
        this.sizeScaler = newStats.sizeScaler;
    }

}
