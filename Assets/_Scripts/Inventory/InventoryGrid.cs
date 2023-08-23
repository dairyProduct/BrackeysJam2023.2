using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    public InventoryController owingInventory;
    public GameObject inventoryItemPrefab;

    public InventorySlot[] slots;

    private void Start() {
        AddSlots();
        UpdateInventory();
    }

    public void AddSlots() {
        slots = new InventorySlot[owingInventory.inventorySize];
        for (int i = 0; i < owingInventory.inventorySize; i++)
        {
            GameObject go = Instantiate(inventoryItemPrefab, transform);
            slots[i] = go.GetComponent<InventorySlot>();
            slots[i].slotIndex = i;
        }
    }

    public void UpdateInventory() {
        for (int i = 0; i < slots.Length; i++)
        {

        }
    }
}
