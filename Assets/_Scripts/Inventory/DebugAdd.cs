using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAdd : MonoBehaviour
{
    public Item[] items;
    
    public InventoryController inventoryController;

    public void Add() {
        inventoryController.Add(items[Random.Range(0, items.Length)].GetItemInstance());
    }
}
