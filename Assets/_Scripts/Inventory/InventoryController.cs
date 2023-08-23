using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public int inventorySize = 25;

    public bool isDirty;

    public bool Add(Item itemToAdd) {
        //Add Item to Stack
        foreach (Item item in inventory)
        {
            if(item.ID == itemToAdd.ID && item.quantity < item.stackSize) {
                item.quantity += itemToAdd.quantity;
                if(item.quantity > item.stackSize) {
                    //Set Stack Size
                    itemToAdd.quantity = item.quantity - item.stackSize;
                    item.quantity = item.stackSize;
                    //Stack Overflow
                    isDirty = true;
                    return Add(itemToAdd);
                } else {
                    isDirty = true;
                    return true;
                }
            }
        }
        //Add a new Item to inventory
        if(inventory.Count < inventorySize) {
            inventory.Add(itemToAdd);
            isDirty = true;
            return true;
        }

        return false;
    }

    public bool RemoveItem() {
        return false;
    }
}
