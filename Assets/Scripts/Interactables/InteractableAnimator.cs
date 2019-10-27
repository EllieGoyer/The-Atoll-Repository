using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Interactable))]
public class InteractableAnimator : MonoBehaviour
{
    Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        Interactable interactable = GetComponent<Interactable>();

        interactable.OnEnabled.AddListener(SetParameterEnabled);
        interactable.OnDisabled.AddListener(UnSetParameterEnabled);
        interactable.OnActivated.AddListener(SetParameterActive);
        interactable.OnDeactivated.AddListener(UnSetParameterActive);
        interactable.OnPerforming.AddListener(SetTriggerPerforming);
    }

    void SetParameterEnabled() {
        animator.SetBool("Enabled", true);
    }
    void UnSetParameterEnabled() {
        animator.SetBool("Enabled", false);
    }

    void SetParameterActive() {
        animator.SetBool("Active", true);

    }
    void UnSetParameterActive() {
        animator.SetBool("Active", false);

    }

    void SetTriggerPerforming() {
        animator.SetTrigger("Performing");
    }
}
