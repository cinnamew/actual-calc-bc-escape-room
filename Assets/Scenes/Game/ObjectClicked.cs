using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ObjectClicked : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] Fungus.Flowchart flowchart;
    [SerializeField] GameObject objectToShow;
    [SerializeField] InventorySystem inv;
    //[SerializeField] InventoryItem itemNeeded;
    //[SerializeField] bool working = true;
    private Manager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        if(manager == null) manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
        if(inv == null) inv = GameObject.Find("inventory").GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        if(!manager.GetCanClick()) return;
        //working = false;
        manager.SetCanClick(false);
        switch(name) {
            case "guard":
                flowchart.ExecuteBlock("guard");
                break;
            case "spider":
                if(!manager.getTalkedToSpider()) {
                    flowchart.ExecuteBlock("spider first time");
                }else {
                    //NEED TO CHECK 
                    if(inv.HasItem("food")) {
                        flowchart.ExecuteBlock("spider yes food");
                        print("has food yumm");
                    }else {
                        if(manager.GetGaveFoodToSpider()) flowchart.ExecuteBlock("spider more");
                        else flowchart.ExecuteBlock("spider no food");
                        Debug.Log("no food");
                    }
                }
                break;
            default:
                //working = true;
                manager.SetCanClick(true);
                break;
        }
    }

    public void SetGaveFoodToSpider(bool a) {
        manager.SetGaveFoodToSpider(a);
    }

    public void SetWorking(bool a) {
        manager.SetCanClick(a);
    }

}
