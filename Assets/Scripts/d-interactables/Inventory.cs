using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static Inventory Instance; // singleton design pattern

    public List<Tool> Tools;
    public List<Collectable> Collectables;
    public Dictionary<Good, int> Goods;
    public Dictionary<Relationship, float> Relationships;

    private void Awake() {
        // set object up as a singleton
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// check if the player has the supplied Tool, TRUE if yes, FALSE if no
    /// </summary>
    /// <param name="tool"></param>
    /// <returns></returns>
    public bool CheckTool(Tool tool) {
        return Tools.Contains(tool);
    }

    /// <summary>
    /// check if the player has the supplied Collectable, TRUE if yes, FALSE if no
    /// </summary>
    /// <param name="Collectable"></param>
    /// <returns></returns>
    public bool CheckCollectable(Collectable collectable) {
        return Collectables.Contains(collectable);
    }

    /// <summary>
    /// check the amount of the supplied good the player has. returns null if that good does not exist.
    /// </summary>
    /// <param name="good"></param>
    /// <returns></returns>
    public int? CheckGood(Good good) {
        if (!Goods.ContainsKey(good)) return null;

        return Goods[good];
    }

    /// <summary>
    /// check the value of the supplied relationship. returns null if that relationship does not exist.
    /// </summary>
    /// <param name="good"></param>
    /// <returns></returns>
    public float? CheckRelationship(Relationship relationship) {
        if (!Relationships.ContainsKey(relationship)) return null;

        return Relationships[relationship];
    }
}
