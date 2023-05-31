using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    
    [SerializeField] int currWall;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        
        GameObject[] e = GameObject.FindGameObjectsWithTag("manager");
        if(e.Length > 1) {
            Destroy(e[0]);
        }else {
            //set up
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrWall() {
        return currWall;
    }

    public void ChangeWall(int newWall) {
        currWall = newWall;
    }
}
