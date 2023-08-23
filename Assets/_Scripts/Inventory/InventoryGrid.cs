using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    public InventoryController owingInventory;
    public GameObject inventorySlotPrefab;
    public GameObject inventoryItemPrefab;

    public InventorySlot[] slots;
    public List<InventoryItem> items = new List<InventoryItem>();

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

    public void AddItems() {
        //Add Items if they have a slot index
        /*
        if(item.wasSlotted) { //Add Item to slot if has slot index
                GameObject go = Instantiate(inventoryItemPrefab, slots[item.slotIndex].transform);
                slots[item.slotIndex].slottedItem = go.GetComponent<InventoryItem>();
            } else { //Add item to new free slot
                InventorySlot openSlot = FindFirstOpenSlot();
                GameObject go = Instantiate(inventoryItemPrefab, openSlot.transform);
                openSlot.slottedItem = go.GetComponent<InventoryItem>();
                go.GetComponent<InventoryItem>().slot = openSlot;
                go.GetComponent<InventoryItem>().SetOwner(item);
                items.Add(go);
            }
            */
    }

    public void UpdateInventory() {
        foreach (InventoryItem item in items)
        {
            item.UpdateItem();
        }
    }


    InventorySlot FindFirstOpenSlot() {
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].slottedItem == null) {
                return slots[i];
            }
        }
        return null;
    }
}
