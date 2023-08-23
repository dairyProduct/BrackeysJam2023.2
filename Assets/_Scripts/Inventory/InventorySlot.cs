using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int slotIndex;
    
    public InventoryItem slottedItem;

    public GameObject itemPrefab;


    public void OnDrop(PointerEventData eventData) {

    }

}
