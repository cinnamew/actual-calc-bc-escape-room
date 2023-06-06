using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmolArrows : MonoBehaviour
{
    [SerializeField] Image upArrow;
    [SerializeField] Image downArrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset() {
        upArrow.enabled = false;
        downArrow.enabled = false;
    }

    public void ShowArrow(string a) {
        if(a == "1") {
            //up
            upArrow.enabled = true;
        }else {
            downArrow.enabled = true;
        }
    }
}
