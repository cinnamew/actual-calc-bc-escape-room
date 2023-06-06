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

            for(int i = 0; i < slots.Count; i++) {  //i think it's also fine if u start from currSlot+1 but just in case
                
                if(slots[i].itemID == null || slots[i].itemID == "") {
                    currSlot = i;
                    break;
                }
            }
            slots[currSlot].Set(newItem);
            
        }
    }

    public InventoryItem Get(InventoryItemData refData) {
        if(m_itemDictionary.TryGetValue(refData, out InventoryItem value)) {
            return value;
        }
        return null;
    }

    public bool HasItem(string id) {
        for(int i = 0; i < inventory.Count; i++) {
            //print(inventory[i].data.id);
            if(inventory[i].data.id == id) return true;
        }
        return false;
    }

    public void Remove(InventoryItemData refData) {
        if(m_itemDictionary.TryGetValue(refData, out InventoryItem value)) {
            value.RemoveFromStack();
            if(value.stackSize == 0) {
                inventory.Remove(value);
                m_itemDictionary.Remove(refData);
                for(int i = 0; i < slots.Count; i++) {
                    if(slots[i].itemID == refData.id) {
                        print("removing");
                        slots[i].Remove();
                        currSlot = i;  
                    }
                }
            }
        }
    }

}
