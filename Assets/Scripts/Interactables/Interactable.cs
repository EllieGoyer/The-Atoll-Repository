using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TOOL {
    none,
    shovel,
    fishingRod,
    axe,
    net
}

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour 
{
    [HideInInspector] public Check[] Checks;

    public UnityEvent OnEnabled; // invoked when leaving the "disabled" state
    public UnityEvent OnDisabled; // invoked when entering the "disabled" state
    public UnityEvent OnActivated; // invoked when entering the "activate" state
    public UnityEvent OnDeactivated; // invoked when entering the "inactive" state
    public UnityEvent OnPerforming; // invoked when entering the "performing" state

    bool isPlayerInside = false;

        public enum STATE {
        Disabled, // the interactable cannot be triggered
        Inactive, // the interactable is invisible
        Active, // the interactable is visible
        Performing, // the interactable is being used
    }
    // the state machine for the interactable, ONLY change state through the property
    STATE currentState;
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
                OnDeactivated.Invoke();
                OnPerforming.Invoke();
            }

            // change the state
            currentState = value;
        }
    }

    // DEFAULT UNITY METHODS

    private void Awake() {
        CurrentState = STATE.Inactive;
        Checks = GetComponents<Check>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // the player entered the trigger, we should try setting the interactable to active
            isPlayerInside = true;
            if (CurrentState == STATE.Inactive && CanActivate()) CurrentState = STATE.Active;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            // the player left the trigger, we should try setting the interactable to inactive
            isPlayerInside = false;
            if (CurrentState == STATE.Active) CurrentState = STATE.Inactive;
        }
    }
    private void Update() {

        // hard-coded player input for the moment - if the player presses E on keyboard of A on controller
        if (Input.GetButtonDown("Interact")) {
            TryActivate();
        }
    }

    /// <summary>
    /// activate this interactable
    /// </summary>
    public void Interact() {
        // require that the interactable is active
        if (CurrentState != STATE.Active) return;
        
        CurrentState = STATE.Performing;
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
        if (isPlayerInside) {
            CurrentState = STATE.Active;
        }
        else {
            CurrentState = STATE.Inactive;
        }
    }
    void TryActivate() {
        if( CurrentState == STATE.Active) {
            CurrentState = STATE.Performing;
        }
    }
    public void Reset() {
        CurrentState = STATE.Inactive;
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