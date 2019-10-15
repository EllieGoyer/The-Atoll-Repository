using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTriggerTest : MonoBehaviour
{
    public Collider InsidePlayer;

    [SerializeField] private bool active;
    public bool Active {
        get { return active; }
        set {
            if(value) {
                GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else {
                GetComponent<MeshRenderer>().material.color = Color.white;
            }
            active = value;
        }
    }

    public bool FlickerActive = false;

    private void Update() {
        if(FlickerActive) {
            FlickerActive = false;
            Collider c = GetComponent<Collider>();
            c.enabled = false;
            c.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            InsidePlayer = other;
            Active = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            // the player left the trigger, we should try setting the interactable to inactive
            if (InsidePlayer != other) {
                CheckInsidePlayer();
            }
            else {
                InsidePlayer = null;
                Active = false;
            }
        }
    }

    private void CheckInsidePlayer() {
        if (InsidePlayer == null) return;

        if (!InsidePlayer.gameObject.activeInHierarchy || !InsidePlayer.CompareTag("Player")) {
            InsidePlayer = null;
            Active = false;
        }
    }
}
