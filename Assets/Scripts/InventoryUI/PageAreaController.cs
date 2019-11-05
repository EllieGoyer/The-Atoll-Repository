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


        print(tabs.Length);

        changeTab(0);
    }

    public void changeTab(int x)
    {
        print(tabs[x].name);
        for (int i = 0; i < tabs.Length; i++)
        {
            
            tabs[i].enabled = false;
        }
        tabs[x].enabled = true;
        

        
        DrawTools._instance.draw();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
