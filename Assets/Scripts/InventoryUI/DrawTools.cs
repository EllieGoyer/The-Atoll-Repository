using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DrawTools : MonoBehaviour
{
    public static DrawTools Instance;

    public GameObject prefab;
    public int num;

    private void Awake()
    {
        // set object up as a singleton
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    public void draw()
    {
        GameObject newObj;


        List<Tool> tools = Inventory.Instance.getTools();

        foreach(Tool t in tools)
        {
            print(t.name);
            print("HELLO");

            

            prefab.GetComponent<Image>().sprite = Sprite.Create(AssetPreview.GetAssetPreview(t.prefab), new Rect(0, 0, 128, 128), new Vector2());

            newObj = (GameObject)Instantiate(prefab, transform);
        }

      /*  for(int i =0; i < num; i++)
        {
            
             newObj = (GameObject)Instantiate(prefab, transform);
             newObj.GetComponent<Image>().color = Random.ColorHSV();
        }*/
    }
}
