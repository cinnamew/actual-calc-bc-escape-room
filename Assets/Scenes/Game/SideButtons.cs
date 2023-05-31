using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideButtons : MonoBehaviour
{
    private Button btn;
    [SerializeField] bool goRight = true;
    [SerializeField] GameObject[] walls;
    private Manager manager;
    

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(ChangeWall);
        if(manager == null) manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
    }

    void ChangeWall() {
        int currWall = manager.GetCurrWall();
        walls[currWall].SetActive(false);
        if(goRight) currWall++;
        else currWall--;
        if(currWall == 4) currWall = 0;
        else if(currWall == -1) currWall = 3;
        walls[currWall].SetActive(true);

        manager.ChangeWall(currWall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
