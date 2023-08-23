using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
    [HideInInspector]
    public string ID = Guid.NewGuid().ToString();
    
    public string itemName = "Item Name";
    public string description = "A long Item description";
    public int quantity = 1;
    public int stackSize = 16;
    public bool canStack = false;
    public Sprite icon;

    [Tooltip("Inventory")]
    public bool wasSlotted;
    public int slotIndex;


    public Item GetItemInstance() {
        return Instantiate(this);
    }

}
