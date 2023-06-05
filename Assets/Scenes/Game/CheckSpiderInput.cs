using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class CheckSpiderInput : MonoBehaviour
{
    private InputField inputTextField;
    [SerializeField] TMP_Text txt;
    [SerializeField] Fungus.Flowchart flowchart;
    
    // Start is called before the first frame update
    void Start()
    {
        inputTextField = GetComponent<InputField>();
    }

    public void CheckPassword() {
        print(txt.text);
        switch(txt.text) {
            case "41​":
                print("correct!");
                flowchart.ExecuteBlock("spider correct");
                break;
            case "TEAM SWAGSTARS HELL EYAH​":
                print("so true");
                break;
            default:
                print("wrong!");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
