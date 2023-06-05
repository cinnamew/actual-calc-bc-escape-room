using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void OnMouseDown() {
        //Debug.Log("item clicked!");
        OnPickupItem();
    }

    public void OnPickupItem() {
        Destroy(gameObject);
        GameObject.Find("inventory").GetComponent<InventorySystem>().Add(referenceItem);
    }
}
