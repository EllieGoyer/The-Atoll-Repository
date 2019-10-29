using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageAreaController : MonoBehaviour
{

    private Canvas[] tabs;

    private Canvas current;

    // Start is called before the first frame update
    void Start()
    {
        tabs = this.GetComponentsInChildren<Canvas>(true);

 
        current.enabled = true;
    }

    public void changeTab(int x)
    {
        
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].enabled = false;
        }
        tabs[x].enabled = true;

        
        DrawTools.Instance.draw();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
