using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawGoods : MonoBehaviour
{

    public static DrawGoods _instance;

    public TextMeshProUGUI tm;
    public TextMeshProUGUI tm2;

    // pictures tools
    public Texture axe;
    public Texture fishRod;


    // pictures goods
    public Texture rocks;
    public Texture wood;

    // raw imagePre
    public RawImage prefab;



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
        RawImage[] ri = tm.GetComponentsInChildren<RawImage>(true);

        foreach (Tool t in Inventory.Instance.Tools)
        {
            // check if we have the tool
            bool contain = false;
            foreach (RawImage b in ri)
            {
                if (b.name.Equals(t.name))
                {
                    contain = true;
                }
            }

            print(t.name);
            if (!contain)
            {
                RawImage newButton = (RawImage)Instantiate(prefab);
                newButton.name = t.name;

                if(t.name.StartsWith("A"))
                {
                    newButton.texture = axe;
                }
                if (t.name.StartsWith("F"))
                {
                    newButton.texture = fishRod;
                }

               

                newButton.transform.SetParent(tm.transform, false);

            }



        }

        RawImage[] ri2 = tm2.GetComponentsInChildren<RawImage>(true);

        foreach (StoredGood t in Inventory.Instance.Goods)
        {
            // check if we have the tool
            bool contain = false;
            foreach (RawImage b in ri2)
            {
                if (b.name.Equals(t.good.name))
                {
                    contain = true;
                }
            }

            
            if (!contain)
            {
                RawImage newButton1 = (RawImage)Instantiate(prefab);
                newButton1.name = t.good.name;

                if (t.good.name.StartsWith("S"))
                {
                    newButton1.texture = rocks;
                }
                else
                {
                    newButton1.texture = wood;
                }

                newButton1.transform.SetParent(tm2.transform, false);

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
