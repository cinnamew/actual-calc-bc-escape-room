using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image m_icon;
    [SerializeField] TMP_Text m_stackLabel;
    public string itemID;
    [SerializeField] GameObject popup;
    private ItemPopups itemPopups;
    
    public void Set(InventoryItem item) {
        m_icon.sprite = item.data.icon;
        m_icon.enabled = true;
        if(item.stackSize <= 1 && m_stackLabel != null) {
            m_stackLabel.enabled = false;
        }else {
            m_stackLabel.enabled = true;
            m_stackLabel.text = item.stackSize.ToString();
        }
        itemID = item.data.id;
        //print("length: " + itemPopups.popups.Length);

        if(item.data.popupNum != -1) popup = itemPopups.popups[item.data.popupNum];
    }

    public void Remove() {
        m_icon.sprite = null;
        m_icon.enabled = false;
        m_stackLabel.enabled = false;
        itemID = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        //m_stackLabel = GetComponent<TMP_Text>();
        if(itemPopups == null) itemPopups = GameObject.FindGameObjectWithTag("item popups").gameObject.GetComponent<ItemPopups>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnMouseDown() {
    //    Debug.Log("mouse was clicked here");
    //    if(m_icon == null) return;
    //    Debug.Log("item in inventory clicked!");
    //}

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(itemID == "" || popup == null) return;
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        //if(popup != null) Debug.Log("clicked inventory item (in inventory) >:D");
        if(!popup.activeSelf) {
            popup.SetActive(true);
            //print("aslkdhsglkasd shwoing popup");
        }else popup.SetActive(false);
    }

}
