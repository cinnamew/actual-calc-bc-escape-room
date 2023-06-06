using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ArrowsLock : MonoBehaviour
{
    
    [SerializeField] string ans = "100110";
    [SerializeField] string curr = "";
    [SerializeField] bool working = true;
    [SerializeField] List<SmolArrows> smolArrows;
    //int currNum = 0;
    [SerializeField] Flowchart flowchart;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCurr(string whatToAdd) {
        if(!working) return;
        curr += whatToAdd;

        //OLD LOGIC
        //if(ans.Substring(0, curr.Length) != curr) {
        //    if(curr[curr.Length - 1] != ans[0]) curr = "";
        //    else curr = curr[curr.Length - 1] + "";
        //}

        smolArrows[curr.Length - 1].ShowArrow(whatToAdd);

        if(curr.Length < 6) return;
        if(ans == curr) {
            Debug.Log("YOU UNLOCKED THE BINARY NUMBER LOCK THINGY!!");
            this.gameObject.SetActive(false);
            flowchart.ExecuteBlock("bracelet unlocked");
            working = false;
        }else {
            flowchart.ExecuteBlock("bracelet combo wrong");
            for(int i = 0; i < smolArrows.Count; i++) {
                smolArrows[i].Reset();
            }
            curr = "";
        }

    }
}
