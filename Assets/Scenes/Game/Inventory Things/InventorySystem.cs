using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory {get; private set;}
    [SerializeField] List<InventorySlot> slots;
    [SerializeField] int currSlot = 0;

    void Awake() {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public void Add(InventoryItemData refData) {
        if(m_itemDictionary.TryGetValue(refData, out InventoryItem value)) {
            //already have at least 1 of this item
            value.AddToStack();
        }else { //NEW ITEM HELL YEAH
            InventoryItem newItem = new InventoryItem(refData);
            inventory.Add(newItem);
            m_itemDictionary.Add(refData, newItem);

            slots[currSlot].Set(newItem);
            currSlot++;
        }



    }

}
