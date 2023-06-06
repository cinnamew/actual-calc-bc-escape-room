using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    
    [SerializeField] int currWall;
    private bool talkedToSpider;
    private bool canClick;
    private bool gaveFoodToSpider;
    private bool doneWithBox;
    private bool addedSilk;
    
    // Start is called before the first frame update
    void Start()
    {
        // USE BELOW TO GET THE MANAGER
        // if(manager == null) manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
    }

    void Awake() {
        
        GameObject[] e = GameObject.FindGameObjectsWithTag("manager");
        if(e.Length > 1) {
            Destroy(e[0]);
        }else {
            talkedToSpider = false;
            canClick = false;
            gaveFoodToSpider = false;
            doneWithBox = false;
            //set up
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetDoneWBox() {
        return doneWithBox;
    }

    public void SetDoneWBox(bool a) {
        doneWithBox = a;
    }

    public bool GetGaveFoodToSpider() {
        return gaveFoodToSpider;
    }

    public void SetGaveFoodToSpider(bool a) {
        gaveFoodToSpider = a;
    }

    public bool GetCanClick() {
        return canClick;
    }

    public void SetCanClick(bool a) {
        canClick = a;
    }

    public bool getTalkedToSpider() {
        bool temp = talkedToSpider;
        if(!talkedToSpider) talkedToSpider = true;
        return temp;
    }

    public int GetCurrWall() {
        return currWall;
    }

    public void ChangeWall(int newWall) {
        currWall = newWall;
    }

    public bool GetAddedSilk() {
        return addedSilk;
    }

    public void SetAddedSilk(bool a) {
        addedSilk = a;
    }
}
