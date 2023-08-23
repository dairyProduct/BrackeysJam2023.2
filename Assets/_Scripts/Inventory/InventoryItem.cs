using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Item owningItem;
    public InventorySlot slot;

    public Transform itemTransform;

    public Image icon;
    public TMP_Text quantityText;
    private void Start() {
        UpdateItem();
    }

    public void SetOwner(Item newItem) {
        owningItem = newItem;
        UpdateItem(); 
    }

    public void UpdateItem() {
        if(owningItem == null) {
            itemTransform.gameObject.SetActive(false);
            return;
        }
        icon.sprite = owningItem.icon;
        quantityText.text = "x" + owningItem.quantity.ToString();
    }
}
