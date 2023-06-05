using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ObjectClicked : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] Fungus.Flowchart flowchart;
    [SerializeField] GameObject objectToShow;
    //[SerializeField] bool working = true;
    private Manager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        if(manager == null) manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
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
                    //NEED TO REPLACE
                    flowchart.ExecuteBlock("spider yes food");
                }
                break;
            default:
                //working = true;
                manager.SetCanClick(true);
                break;
        }
    }

    public void SetWorking(bool a) {
        manager.SetCanClick(a);
    }

}
