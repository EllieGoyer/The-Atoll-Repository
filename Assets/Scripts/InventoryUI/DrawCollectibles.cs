using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DrawCollectibles : MonoBehaviour
{
    public static DrawCollectibles _instance;

   // public Image box;
    public TextMeshProUGUI tm;

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
        /*
        string txt = "";
      
        foreach (Tool tool in Inventory.Instance.Tools)
        {
            txt += tool.name + ", ";
        }

        tm.text = txt;


        /* foreach (Tool t in Inventory.Instance.Tools)
              {
                  print(t.name);
              }



             for(int i =0; i < num; i++)
                {
                    box.sprite = Sprite.Create(AssetPreview.GetAssetPreview(t.prefab), new Rect(0, 0, 128, 128), new Vector2());
                     newObj = (GameObject)Instantiate(prefab, transform);
                     newObj.GetComponent<Image>().color = Random.ColorHSV();
                }*/
    }
}
