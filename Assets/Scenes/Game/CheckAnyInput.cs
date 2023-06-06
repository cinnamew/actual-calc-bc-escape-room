using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using TMPro;
using UnityEngine.UI;

public class CheckAnyInput : MonoBehaviour
{
    [SerializeField] bool setWorkingAfter = true;
    [SerializeField] string password;
    [SerializeField] string id;
    [SerializeField] GameObject whatToHide;

    private InputField inputTextField;
    [SerializeField] TMP_Text txt;
    [SerializeField] Fungus.Flowchart flowchart;
    
    // Start is called before the first frame update
    void Start()
    {
        inputTextField = GetComponent<InputField>();
    }

    public void CheckPW() {
        print(txt.text);
        if(txt.text == (password + "​")) {
            OnUnlocked();
        }else {
            if(id == "bracelet") {
                flowchart.ExecuteBlock("bracelet frq wrong");
            }
        }
    }

    public void OnUnlocked() {
        if(setWorkingAfter) flowchart.ExecuteBlock("set working true");
        if(id == "bracelet") {
            whatToHide.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
