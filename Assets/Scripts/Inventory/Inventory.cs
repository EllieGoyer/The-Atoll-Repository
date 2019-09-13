using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour {
    public static Inventory Instance; // singleton design pattern
    public UnityEvent OnInventoryUpdate;

    public List<Tool> Tools;
    public List<Collectable> Collectables;
    public List<StoredGood> Goods;
    public List<StoredRelationship> Relationships;

    private void Awake() {
        // set object up as a singleton
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    StoredGood FindStoredGood(Good good) {
        foreach (StoredGood storedGood in Goods) {
            if (good == storedGood.good) {
                return storedGood;
            }
        }

        return null;
    }
    StoredRelationship FindStoredRelationship(Relationship relationship) {
        foreach (StoredRelationship storedRelationship in Relationships) {
            if (relationship == storedRelationship.relationship) {
                return storedRelationship;
            }
        }

        return null;
    }

    // Check - determine the current status of a particular notebook item
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
        StoredGood storedGood = FindStoredGood(good);

        if (storedGood != null) {
            return storedGood.amount;
        }

        return null;
    }
    /// <summary>
    /// check the value of the supplied relationship. returns null if that relationship does not exist.
    /// </summary>
    /// <param name="good"></param>
    /// <returns></returns>
    public float? CheckRelationship(Relationship relationship) {
        StoredRelationship storedRelationship = FindStoredRelationship(relationship);

        if (storedRelationship != null) {
            return storedRelationship.value;
        }

        return null;
    }

    // Unlock - add a new entry into the inventory
    /// <summary>
    /// Add a new tool to the inventory
    /// </summary>
    /// <param name="tool"></param>
    public void UnlockTool(Tool tool) {
        // if we already have the tool, return
        if (Tools.Contains(tool)) {
            Debug.LogWarning("Tool " + tool.name + " already unlocked");
            return;
        }

        // add as new tool
        Tools.Add(tool);
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// Add a new collectable to the inventory
    /// </summary>
    /// <param name="collectable"></param>
    public void UnlockCollectable(Collectable collectable) {
        // if we already have the collectable, return
        if (Collectables.Contains(collectable)) {
            Debug.LogWarning("Collectable " + collectable.name + " already unlocked");
            return;
        }

        //add as new collectable
        Collectables.Add(collectable);
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// Add a new good to the inventory
    /// </summary>
    /// <param name="good"></param>
    public void UnlockGood(Good good) {
        // if we already have the good, return
        if (FindStoredGood(good) != null) {
            Debug.LogWarning("Good " + good.name + " already unlocked");
            return;
        }

        //add as a new good
        Goods.Add(new StoredGood(good));
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// Add a new relationship to the inventroy
    /// </summary>
    /// <param name="relationship"></param>
    public void UnlockRelationship(Relationship relationship) {
        // if we already have the relationship, return
        if (FindStoredRelationship(relationship) != null) {
            Debug.LogWarning("Relationship " + relationship.name + " already unlocked");
            return;
        }

        //add as new relationship
        Relationships.Add(new StoredRelationship(relationship));
        OnInventoryUpdate.Invoke();
    }

    // Change Good Amount - modify the amount of a good in the inventory
    /// <summary>
    /// Set the amount of a good on the player to some amount
    /// </summary>
    /// <param name="good"></param>
    /// <param name="amount"></param>
    public void SetGoodAmount(Good good, int amount) {
        StoredGood storedGood = FindStoredGood(good);

        if (storedGood == null) {
            Debug.LogWarning("Good " + good.name + " not yet unlocked");
            return;
        }

        storedGood.amount = amount;
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// Add some amount of a good to the player
    /// </summary>
    /// <param name="good"></param>
    /// <param name="amount"></param>
    public void AddGood(Good good, int amount) {
        StoredGood storedGood = FindStoredGood(good);

        if (storedGood == null) {
            UnlockGood(good);
            storedGood = FindStoredGood(good);
            if(storedGood == null) {
                Debug.LogWarning("Failed to unlock good " + good.name + " for adding");
                return;
            }
        }

        storedGood.amount += amount;
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// Remove some amount of a good from the player, bottoming out at zero.
    /// </summary>
    /// <param name="good"></param>
    /// <param name="amount"></param>
    public void SubtractGood(Good good, int amount) {
        StoredGood storedGood = FindStoredGood(good);

        if (storedGood == null) {
            Debug.LogWarning("Good " + good.name + " not yet unlocked");
            return;
        }

        storedGood.amount = Mathf.Max(storedGood.amount-Mathf.Abs(amount),0);
        OnInventoryUpdate.Invoke();
    }

    // Change relationship value - modify the value of a player's relationship
    /// <summary>
    /// set the value of the supplied relationship
    /// </summary>
    /// <param name="relationship"></param>
    /// <param name="value"></param>
    public void SetRelationshipValue(Relationship relationship, float value) {
        StoredRelationship storedRelationship = FindStoredRelationship(relationship);

        if (storedRelationship == null) {
            Debug.LogWarning("Relationship " + relationship.name + " not yet unlocked");
            return;
        }
        
        storedRelationship.value = Relationship.ClampValue(value);
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// add to the value of the supplied relationship
    /// </summary>
    /// <param name="relationship"></param>
    /// <param name="value"></param>
    public void AddRelationshipValue(Relationship relationship, float value) {
        StoredRelationship storedRelationship = FindStoredRelationship(relationship);

        if (storedRelationship == null) {
            Debug.LogWarning("Relationship " + relationship.name + " not yet unlocked");
            return;
        }
        
        storedRelationship.value = Relationship.ClampValue(storedRelationship.value + value);
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// subtract from the value of the supplied relationship
    /// </summary>
    /// <param name="relationship"></param>
    /// <param name="value"></param>
    public void SubtractRelationshipValue(Relationship relationship, float value) {
        StoredRelationship storedRelationship = FindStoredRelationship(relationship);

        if (storedRelationship == null) {
            Debug.LogWarning("Relationship " + relationship.name + " not yet unlocked");
            return;
        }

        storedRelationship.value = Relationship.ClampValue(storedRelationship.value - value);
        OnInventoryUpdate.Invoke();
    }

    public static void Foo() {

    }
}
