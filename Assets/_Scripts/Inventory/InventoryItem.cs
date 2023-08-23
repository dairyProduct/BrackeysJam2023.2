using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Item owningItem;

    public Transform itemTransform;

    public Image icon;
    public TMP_Text quantityText;
    private void Start() {
        if (owningItem == null) {

        }
    }

    public void UpdateItem() {
        if(owningItem == null) {
            ico
        }


    }
}
