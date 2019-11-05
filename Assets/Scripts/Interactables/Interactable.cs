using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour 
{
    [HideInInspector] public Check[] Checks;

    [SerializeField] [HideInInspector] public bool AutoReset = false;
    [SerializeField] [HideInInspector] public float ResetCooldownTime = 0;

    public UnityEvent OnEnabled; // invoked when leaving the "disabled" state
    public UnityEvent OnDisabled; // invoked when entering the "disabled" state
    public UnityEvent OnActivated; // invoked when entering the "activate" state
    public UnityEvent OnDeactivated; // invoked when entering the "inactive" state
    public UnityEvent OnPerforming; // invoked when entering the "performing" state
    [HideInInspector] public UnityEvent OnReset;

    Collider InsidePlayer = null;
    new Collider collider;

    public enum STATE {
        Disabled, // the interactable cannot be triggered
        Inactive, // the interactable is invisible
        Active, // the interactable is visible
        Performing, // the interactable is being used
    }

    // the state machine for the interactable, ONLY change state through the property
    public STATE currentState;
    
    public STATE CurrentState {
        get { return currentState; }
        set {
            // if no change happens, don't invoke any events
            if (currentState == value) return;

            // invoke events based on how the states were changed
            if (value == STATE.Disabled) {

                // if we start in active, we want to deactivate AND disable
                if (currentState == STATE.Active) OnDeactivated.Invoke();
                OnDisabled.Invoke();

            }
            else if (value == STATE.Inactive) {
                if (currentState == STATE.Disabled) {
                    OnEnabled.Invoke();
                }
                else {
                    OnDeactivated.Invoke();
                }
            }
            else if (value == STATE.Active) {

                // if we start in disabled, we want to enable AND activate
                if (currentState == STATE.Disabled) OnEnabled.Invoke();
                OnActivated.Invoke();
            }
            else { // if (value == STATE.Performing) {
                OnPerforming.Invoke();
            }

            // change the state
            currentState = value;
        }
    }

    // DEFAULT UNITY METHODS

    private void Awake() {
        OnReset = new UnityEvent();
        Checks = GetComponents<Check>();
        collider = GetComponent<Collider>();
        currentState = STATE.Inactive;
    }



    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // the player entered the trigger, we should try setting the interactable to active
            InsidePlayer = other;
            if (CurrentState == STATE.Inactive && CanActivate()) CurrentState = STATE.Active;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            // the player left the trigger, we should try setting the interactable to inactive
            if(InsidePlayer != other) {
                CheckInsidePlayer();
            }
            else {
                InsidePlayer = null;
                if (CurrentState == STATE.Active) CurrentState = STATE.Inactive;
            }
        }
    }

    private void Update() {

        CheckInsidePlayer();

        if (Input.GetButtonDown("Interact")) {
            Interact();
        }
    }

    private void CheckInsidePlayer() {
        if (InsidePlayer == null) return;

        if(!InsidePlayer.gameObject.activeInHierarchy || !InsidePlayer.CompareTag("Player") ) {
            InsidePlayer = null;
            if (CurrentState == STATE.Active) CurrentState = STATE.Inactive;
        }
    }
    public void ResetTrigger() {
        if (CurrentState == STATE.Active) CurrentState = STATE.Inactive;
        InsidePlayer = null;
        collider.enabled = false;
        collider.enabled = true;
    }

    /// <summary>
    /// activate this interactable
    /// </summary>
    public void Interact() {
        // require that the interactable is active
        if (CurrentState != STATE.Active) return;
        
        CurrentState = STATE.Performing;
        if (AutoReset) {
            if(ResetCooldownTime > 0) {
                ResetDelayed(ResetCooldownTime);
            }
            else {
                OnReset.Invoke();
            }

            CurrentState = STATE.Active;
        }
        else {
            CurrentState = STATE.Disabled;
        }
    }
    /// <summary>
    /// set the interactable to the disabled state
    /// </summary>
    public void Disable() {
        CurrentState = STATE.Disabled;
    }
    /// <summary>
    /// set the interactable to the Inactive state
    /// </summary>
    public void Enable() {
        if (InsidePlayer != null) {
            CurrentState = STATE.Active;
        }
        else {
            CurrentState = STATE.Inactive;
        }
    }

    public void ResetDelayed(float delayTime) {
        StartCoroutine(ResetAfterDelay(delayTime));
    }
    IEnumerator ResetAfterDelay(float delayTime) {
            yield return new WaitForSeconds(delayTime);
        Reset();
    }
    public void Reset() {
        CurrentState = STATE.Inactive;
        ResetTrigger();
        OnReset.Invoke();
    }

    /// <summary>
    /// whether or not this interactable can be activated right now
    /// </summary>
    /// <returns></returns>
    public bool CanActivate() {
        
        //if we're disabled, we can't get activated
        if (CurrentState == STATE.Disabled) return false;

        //if one of our checks fails, we can't get activated
        foreach(Check check in Checks) {
            if (!check.Perform()) return false;
        }

        //otherwise, we are good to get activated
        return true;
    }


}
