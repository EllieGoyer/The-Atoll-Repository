using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageAreaController : MonoBehaviour
{

    private Image[] tabs;

    private Image current;

    // Start is called before the first frame update
    void Start()
    {
        tabs = this.GetComponentsInChildren<Image>(true);

        print(tabs);

        current.enabled = true;
    }

    public void changeTab(int x)
    {
        for(int i = 1; i < tabs.Length; i++)
        {
            tabs[i].enabled = false;
        }
        tabs[x+1].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
