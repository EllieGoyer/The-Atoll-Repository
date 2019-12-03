using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class DrawCollectibles : MonoBehaviour
{
    public static DrawCollectibles _instance;

   // public Image box;
    public TextMeshProUGUI tm;
    public Button prefab;

  

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void draw()
    {
        Button[] bb = tm.GetComponentsInChildren<Button>(true);


        foreach (Collectable c in Inventory.Instance.Collectables)
        {

            // check if we have the person
            bool contain = false;
            foreach (Button b in bb)
            {
                if (b.name.Equals(c.name))
                {
                    contain = true;
                }
            }

            if (!contain)
            {
                Button newButton = (Button)Instantiate(prefab);
                newButton.name = c.name;

                newButton.GetComponentInChildren<Text>().text = c.name;
                newButton.transform.SetParent(tm.transform, false);
            }


        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
}
