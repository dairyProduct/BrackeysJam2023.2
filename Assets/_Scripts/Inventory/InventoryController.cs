using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public int inventorySize = 25;

    public delegate void InventoryDelegate();
    public InventoryDelegate UpdateInventory;

    public void Add(Item itemToAdd) {
        //Add Item to Stack
        foreach (Item item in inventory)
        {
            if(item.ID == itemToAdd.ID && item.quantity < item.stackSize) {
                item.quantity += itemToAdd.quantity;
                if(item.quantity > item.stackSize) {
                    //Set Stack Size
                    itemToAdd.quantity = item.quantity - item.stackSize;
                    item.quantity = item.stackSize;
                } else {
                    return;
                }
            }
        }
        //Add a new Item to inventory
        if(inventory.Count <= inventorySize) {
            inventory.Add(itemToAdd);
        }
    }

    public bool RemoveItem() {
        return false;
    }
}
