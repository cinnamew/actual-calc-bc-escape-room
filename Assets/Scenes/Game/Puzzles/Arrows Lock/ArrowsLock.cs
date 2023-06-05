using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsLock : MonoBehaviour
{
    
    [SerializeField] string ans = "100110";
    [SerializeField] string curr = "";
    [SerializeField] bool working = true;
    
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

        if(ans.Substring(0, curr.Length) != curr) {
            if(curr[curr.Length - 1] != ans[0]) curr = "";
            else curr = curr[curr.Length - 1] + "";
        }

        if(ans == curr) {
            Debug.Log("YOU UNLOCKED THE BINARY NUMBER LOCK THINGY!!");
            this.gameObject.SetActive(false);
            working = false;
        }
    }
}
