using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrawRelationships : MonoBehaviour
{
    public TextMeshProUGUI tm;

    public static DrawRelationships _instance;



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

    public void draw()
    {
        string txt = "";
        foreach (StoredRelationship storedRelationship in Inventory.Instance.Relationships)
        {
            //HACK null check just to deal with some uninitialized relation???
            if (storedRelationship != null && storedRelationship.relationship != null)
                txt += storedRelationship.relationship.name + ": " + storedRelationship.amount + "\n";
        }

        tm.text = txt;
    }
}
