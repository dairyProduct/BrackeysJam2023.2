using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] StatBlock mystats;

    public void SetStats(StatBlock stats)
    {
        mystats = stats;
    }

}
