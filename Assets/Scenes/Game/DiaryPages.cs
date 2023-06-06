using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryPages : MonoBehaviour
{
    [SerializeField] List<Image> pages;
    [SerializeField] int currPage;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < pages.Count; i++) {
            pages[i].enabled = false;
        }
    }

    public void TurnPage() {
        if(currPage == pages.Count - 1) return;
        pages[currPage].enabled = false;
        currPage++;
        pages[currPage].enabled = true;
    }

    public void TurnBackPage() {
        if(currPage == 0) return;
        pages[currPage].enabled = false;
        currPage--;
        pages[currPage].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
