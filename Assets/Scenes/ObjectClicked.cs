using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ObjectClicked : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] Fungus.Flowchart flowchart;
    [SerializeField] GameObject objectToShow;
    [SerializeField] bool working = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        if(!working) return;
        working = false;
        switch(name) {
            case "guard":
                flowchart.ExecuteBlock("guard");
                break;
            default:
                working = true;
                break;
        }
    }

    public void SetWorking(bool a) {
        working = a;
    }

}
