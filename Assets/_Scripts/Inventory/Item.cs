using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName = "Item Name";
    public string description = "A long Item description";
    public int quantity = 1;
    public int stackSize = 16;
    public bool canStack = false;
    public Sprite icon;


    public Item GetItemInstance() {
        return Instantiate(this);
    }

    public bool AddToStack() {
        if(!canStack) return false;
    }

}
