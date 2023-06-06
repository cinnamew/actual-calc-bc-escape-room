using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.EventSystems;

public class ObjectClicked : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] Fungus.Flowchart flowchart;
    [SerializeField] GameObject objectToShow;
    [SerializeField] InventorySystem inv;
    //[SerializeField] InventoryItem itemNeeded;
    //[SerializeField] bool working = true;
    private Manager manager;
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        if(manager == null) manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
        if(inv == null) inv = GameObject.Find("inventory").GetComponent<InventorySystem>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        if(!manager.GetCanClick()) return;

        if(EventSystem.current.IsPointerOverGameObject()) {
            //print("aaa");
            return;
        }

        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //RaycastHit hitInfo;
        //if(!Physics.Raycast(ray, out hitInfo, Mathf.Infinity)) {
        //    print("on UI");
        //    return;
        //}

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
                        //print("has food yumm");
                    }else {
                        if(manager.GetGaveFoodToSpider()) flowchart.ExecuteBlock("spider more");
                        else flowchart.ExecuteBlock("spider no food");
                        //Debug.Log("no food");
                    }
                }
                break;
            //case "box close up":
            //    this.gameObject.SetActive(false);
            //    manager.SetCanClick(true);
            //    break;
            case "actual box":
                if(!inv.HasItem("paper")) flowchart.ExecuteBlock("box no paper");
                break;
            case "numlock":
                if(inv.HasItem("paper")) {
                    objectToShow.SetActive(true);
                    //manager.SetCanClick(true);
                }else {
                    flowchart.ExecuteBlock("box no paper");
                }
                break;
            case "vent":
                flowchart.ExecuteBlock("air vent");
                break;
            case "bracelet box":
                manager.SetCanClick(true);
                if(manager.GetDoneWBox()) {
                    flowchart.ExecuteBlock("box empty");
                    break;
                }
                objectToShow.SetActive(true);
                break;
            case "pins":
                print("pins clicked");
                if(!inv.HasItem("spidersilk") && !manager.GetAddedSilk()) {
                    flowchart.ExecuteBlock("pins nothing");
                }else if(inv.HasItem("spidersilk")) {
                    flowchart.ExecuteBlock("pins spider");
                    manager.SetAddedSilk(true);
                }else if(!inv.HasItem("ornfinal") && !inv.HasItem("bracelet")) {
                    flowchart.ExecuteBlock("pins spider nothing");
                }else if(!inv.HasItem("ornfinal")) {
                    flowchart.ExecuteBlock("pins spider no o");
                }else if(inv.HasItem("ornfinal") && inv.HasItem("bracelet")) {
                    flowchart.ExecuteBlock("pins spider done");
                }

                break;
            case "sink":
                if(!inv.HasItem("ornament") && !inv.HasItem("bracelet")) {
                    flowchart.ExecuteBlock("sink nothing");
                }else if(inv.HasItem("bracelet") && !inv.HasItem("ornament")) {
                    flowchart.ExecuteBlock("sink yes b no o");
                }else if(inv.HasItem("ornament")) {
                    flowchart.ExecuteBlock("sink yes o");
                }
                break;
            default:
                //working = true;
                objectToShow.SetActive(true);
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

    public void SetDoneWBox(bool a) {
        manager.SetDoneWBox(a);
    }

}
