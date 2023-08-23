using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    public InventoryController owingInventory;
    public GameObject inventorySlotPrefab;

    public InventorySlot[] slots;

    private void Start() {
        AddSlots();
        UpdateInventory();
    }

    private void Update() {
        if(owingInventory.isDirty) {
            owingInventory.isDirty = false;
            UpdateInventory();
        }
        
    }

    public void AddSlots() {
        slots = new InventorySlot[owingInventory.inventorySize];
        for (int i = 0; i < owingInventory.inventorySize; i++)
        {
            GameObject go = Instantiate(inventorySlotPrefab, transform);
            slots[i] = go.GetComponent<InventorySlot>();
            slots[i].slotIndex = i;
        }
    }

    public void UpdateInventory() {
        foreach (Item item in owingInventory.inventory)
        {
            if(item.wasSlotted) {
                GameObject go = Instantiate(inventorySlotPrefab, slots[item.slotIndex].transform);
                slots[item.slotIndex].slottedItem = go.GetComponent<InventoryItem>();
            } else {
                
            }
        }
    }

    void FindFirstOpenSlot() {

    }
}
