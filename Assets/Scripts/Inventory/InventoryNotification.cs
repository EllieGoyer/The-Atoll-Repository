using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryNotification : MonoBehaviour {
    public float displayTime;

    public TextMeshProUGUI TopText;
    public TextMeshProUGUI BottomText;
    public NotebookItem notebookItem;
    public enum EventType {
        Added,
        Removed,
        AmountAdded,
        AmountRemoved
    }
    public EventType Event;
    public int amount;

    private void Awake() {
        Animator animator = GetComponent<Animator>();

        StartCoroutine(HideDelayed(displayTime));
    }

    IEnumerator HideDelayed(float delay) {
        yield return new WaitForSeconds(delay);
        HideNotification();
    }

    void HideNotification() {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Exit");
    }

    public void UpdateDisplay() {
        // update top text 
        TopText.text = GenerateTopText();
        BottomText.text = notebookItem.Description;
    }
    public string GenerateTopText() {
        switch (Event) {
            case EventType.Added:
                return string.Format("{0} Added", notebookItem.name);
            case EventType.Removed:
                return string.Format("{0} Removed", notebookItem.name);
            case EventType.AmountAdded:
                return string.Format("{0} {1} Added", amount, notebookItem.name);
            case EventType.AmountRemoved:
                return string.Format("{0} {1} Removed", amount, notebookItem.name);
        }

        return null;
    }
    public void DestroyThis() {
        Destroy(gameObject);
    }
}
