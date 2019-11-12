using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawRelationships : MonoBehaviour
{
    public TextMeshProUGUI tm;

    public TextMeshProUGUI name;
    public TextMeshProUGUI proffession;

    public static DrawRelationships _instance;

    public Button prefab;

    public RawImage port;

    
    public Texture bake;
    public Texture farmer;
    public Texture luberjack;
    public Texture potter;
    public Texture tailor;
    

    






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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void onCL(int i, string proff)
    {
        switch (i)
        {
            case 0:
                port.texture = bake;
                proffession.text = proff;
                break;
            case 1:
                port.texture = farmer;
                proffession.text = proff;
                break;
            case 2:
                port.texture = luberjack;
                proffession.text = proff;
                break;
            case 3:
                port.texture = potter;
                proffession.text = proff;
                break;
            case 4:
                port.texture = tailor;
                proffession.text = proff;
                break;

        }
    }

    public void draw()
    {

        Button[] bb = tm.GetComponentsInChildren<Button>(true);

        foreach (StoredRelationship storedRelationship in Inventory.Instance.Relationships)
        {
            

            bool contain = false;
            foreach(Button b in bb)
            {
                if (b.name.Equals(storedRelationship.relationship.name))
                {
                    contain = true;
                }
            }
            if (!contain)
            {
                Button newButton = (Button)Instantiate(prefab);
                newButton.name = storedRelationship.relationship.name;

                switch (newButton.name.ToLower()[0])
                {
                    case 'b':
                        newButton.onClick.AddListener(delegate { onCL(0, newButton.name); });
                        break;
                    case 'f':
                        newButton.onClick.AddListener(delegate { onCL(1, newButton.name); });
                        break;
                    case 'l':
                        newButton.onClick.AddListener(delegate { onCL(2, newButton.name); });
                        break;
                    case 'p':
                        newButton.onClick.AddListener(delegate { onCL(3, newButton.name); });
                        break;
                    case 't':
                        newButton.onClick.AddListener(delegate { onCL(4, newButton.name); });
                        break;
                }
                

                

                newButton.GetComponentInChildren<Text>().text = storedRelationship.relationship.name;
                newButton.transform.SetParent(tm.transform, false);
            }

        }



    }
}
