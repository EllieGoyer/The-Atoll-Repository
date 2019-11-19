using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour {
    GameObject InventoryNotificationPrefab;

    public static Inventory Instance; // singleton design pattern
    public UnityEvent OnInventoryUpdate;

    public List<Tool> Tools;
    public List<Collectable> Collectables;
    public List<StoredGood> Goods;
    public List<StoredRelationship> Relationships;

    public List<Tool> getTools()
    {
        return Tools;
    }

    public List<Collectable> GetCollectables()
    {
        return Collectables;
    }

    public List<StoredGood> GetGoods()
    {
        return Goods;
    }

    public List<StoredRelationship> GetRelationships()
    {
        return Relationships;
    }

    private void Awake() {
        // set object up as a singleton
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        InventoryNotificationPrefab = Resources.Load<GameObject>("Notification");
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
    public int? CheckRelationship(Relationship relationship) {
        StoredRelationship storedRelationship = FindStoredRelationship(relationship);

        if (storedRelationship != null) {
            return storedRelationship.amount;
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
        CreateNotification(tool, InventoryNotification.EventType.Added);
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
        if (!collectable.HideInJournal) {
            CreateNotification(collectable, InventoryNotification.EventType.Added);
        }
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// Remove a collectable from the inventory
    /// </summary>
    /// <param name="collectable"></param>
    public void LockCollectable(Collectable collectable) {
        // if we don't have the collectable, return
        if(!Collectables.Contains(collectable)) {
            Debug.LogWarning("Collectable " + collectable.name + "is not unlocked");
            return;
        }

        //remove the collectable
        Collectables.Remove(collectable);
        if(!collectable.HideInJournal) {
            CreateNotification(collectable, InventoryNotification.EventType.Removed);
        }
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
        if(relationship == null) {
            throw new System.NullReferenceException("Parameter \"relationship\" cannot be null");
        }

        // if we already have the relationship, return
        if (FindStoredRelationship(relationship) != null) {
            Debug.LogWarning("Relationship " + relationship.name + " already unlocked");
            return;
        }

        //add as new relationship
        Relationships.Add(new StoredRelationship(relationship));
        CreateNotification(relationship, InventoryNotification.EventType.Added);

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
    public void AddGoodAmount(Good good, int amount) {
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

        CreateNotification(good, InventoryNotification.EventType.AmountAdded, amount);
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// Remove some amount of a good from the player, bottoming out at zero.
    /// </summary>
    /// <param name="good"></param>
    /// <param name="amount"></param>
    public void SubtractGoodAmount(Good good, int amount) {
        StoredGood storedGood = FindStoredGood(good);

        if (storedGood == null) {
            Debug.LogWarning("Good " + good.name + " not yet unlocked");
            return;
        }

        storedGood.amount = Mathf.Max(storedGood.amount-Mathf.Abs(amount),0);
        CreateNotification(good, InventoryNotification.EventType.AmountRemoved, amount);
        OnInventoryUpdate.Invoke();
    }

    // Change relationship value - modify the value of a player's relationship
    /// <summary>
    /// set the value of the supplied relationship
    /// </summary>
    /// <param name="relationship"></param>
    /// <param name="amount"></param>
    public void SetRelationshipAmount(Relationship relationship, int amount) {
        StoredRelationship storedRelationship = FindStoredRelationship(relationship);

        if (storedRelationship == null) {
            Debug.LogWarning("Relationship " + relationship.name + " not yet unlocked");
            return;
        }
        
        storedRelationship.amount = Relationship.ClampValue(amount);
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// add to the value of the supplied relationship
    /// </summary>
    /// <param name="relationship"></param>
    /// <param name="amount"></param>
    public void AddRelationshipAmount(Relationship relationship, int amount) {
        StoredRelationship storedRelationship = FindStoredRelationship(relationship);

        if (storedRelationship == null) {
            Debug.LogWarning("Relationship " + relationship.name + " not yet unlocked");
            return;
        }
        
        storedRelationship.amount = Relationship.ClampValue(storedRelationship.amount + amount);
        CreateNotification(relationship, InventoryNotification.EventType.AmountAdded, amount);
        OnInventoryUpdate.Invoke();
    }
    /// <summary>
    /// subtract from the value of the supplied relationship
    /// </summary>
    /// <param name="relationship"></param>
    /// <param name="amount"></param>
    public void SubtractRelationshipAmount(Relationship relationship, int amount) {
        StoredRelationship storedRelationship = FindStoredRelationship(relationship);

        if (storedRelationship == null) {
            Debug.LogWarning("Relationship " + relationship.name + " not yet unlocked");
            return;
        }

        storedRelationship.amount = Relationship.ClampValue(storedRelationship.amount - amount);
        CreateNotification(relationship, InventoryNotification.EventType.AmountRemoved, amount);

        OnInventoryUpdate.Invoke();
    }
    
    public void CreateNotification(NotebookItem item, InventoryNotification.EventType type, int amount = -1) {
        InventoryNotification notif = InstantiateNotification();

        notif.notebookItem = item;
        notif.Event = type;
        notif.amount = amount;

        notif.UpdateDisplay();
    }
    
    InventoryNotification InstantiateNotification() {
        GameObject g = Instantiate(InventoryNotificationPrefab, GlobalCanvas.Instance.transform);

        return g.GetComponent<InventoryNotification>();
    }


    public string DebugString() {
        string txt = "****Inventory****\n";

        txt += "Tools: ";
        foreach (Tool tool in Tools) {
            txt += tool.name + ", ";
        }

        txt += "\nCollectibles: ";
        foreach (Collectable collectable in Collectables) {
            txt += collectable.name + ", ";
        }

        txt += "\nGoods:--------------\n";
        foreach (StoredGood storedGood in Goods) {
            txt += storedGood.good.name + ": " + storedGood.amount + "\n";
        }

        txt += "\nRelationships:------\n";
        foreach (StoredRelationship storedRelationship in Relationships) {
            //HACK null check just to deal with some uninitialized relation???
            if(storedRelationship != null && storedRelationship.relationship != null)
                txt += storedRelationship.relationship.name + ": " + storedRelationship.amount + "\n";
        }

        return txt;
    }
}
