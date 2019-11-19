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
    public TextMeshProUGUI relationshipStat;

    public static DrawRelationships _instance;

    public Button prefab;

    public RawImage port;

    
    public Texture bake;
    public Texture farmer;
    public Texture luberjack;
    public Texture potter;
    public Texture tailor;


    private string[] relationshisS = {"Terrible","Bad","Mild","Good","Excellent"};






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

    void onCL(int i, string proff, int rel)
    {
        switch (i)
        {
            case 0:
                port.texture = bake;
                name.text = "Araba";
                proffession.text = proff;
                relationshipStat.text = "Status: " + relationshisS[rel/2/10];
                break;
            case 1:
                port.texture = farmer;
                name.text = "Cerci";
                proffession.text = proff;
                relationshipStat.text = "Status: " + relationshisS[rel / 2 / 10];
                break;
            case 2:
                port.texture = luberjack;
                name.text = "Hal";
                proffession.text = proff;
                relationshipStat.text = "Status: " + relationshisS[rel / 2 / 10];
                break;
            case 3:
                port.texture = potter;
                name.text = "Meryl";
                proffession.text = proff;
                relationshipStat.text = "Status: " + relationshisS[rel / 2 / 10];
                break;
            case 4:
                port.texture = tailor;
                name.text = "Fid";
                proffession.text = proff;
                relationshipStat.text = "Status: " + relationshisS[rel / 2 / 10];
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
                        newButton.onClick.AddListener(delegate { onCL(0, newButton.name, storedRelationship.amount); });
                        break;
                    case 'f':
                        newButton.onClick.AddListener(delegate { onCL(1, newButton.name, storedRelationship.amount); });
                        break;
                    case 'l':
                        newButton.onClick.AddListener(delegate { onCL(2, newButton.name, storedRelationship.amount); });
                        break;
                    case 'p':
                        newButton.onClick.AddListener(delegate { onCL(3, newButton.name, storedRelationship.amount); });
                        break;
                    case 't':
                        newButton.onClick.AddListener(delegate { onCL(4, newButton.name, storedRelationship.amount); });
                        break;
                }
                

                

                newButton.GetComponentInChildren<Text>().text = storedRelationship.relationship.name;
                newButton.transform.SetParent(tm.transform, false);
            }

        }



    }
}
