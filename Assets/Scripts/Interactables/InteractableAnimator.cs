using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Interactable))]
public class InteractableAnimator : MonoBehaviour
{
    public enum TYPE {
        Normal,
        Toy
    }
    public TYPE Type;
    
    public Material DefaultMaterial;
    public Material ActivatedMaterial;

    public Renderer[] renderers;

    Animator animator;

    public void SetMaterialActivated() {
        foreach(Renderer r in renderers) {
            r.material = ActivatedMaterial;
        }
    }
    public void SetMaterialDeActivated() {
        foreach (Renderer r in renderers) {
            r.material = DefaultMaterial;
        }
    }


    private void Start() {
        animator = GetComponent<Animator>();
        Interactable interactable = GetComponent<Interactable>();

        interactable.OnEnabled.AddListener(SetParameterEnabled);
        interactable.OnDisabled.AddListener(UnSetParameterEnabled);
        interactable.OnActivated.AddListener(SetParameterActive);
        interactable.OnDeactivated.AddListener(UnSetParameterActive);
        interactable.OnPerforming.AddListener(SetTriggerPerforming);
        interactable.OnReset.AddListener(SetTriggerReset);
    }

    void SetParameterEnabled() {
        animator.SetBool("Enabled", true);
    }
    void UnSetParameterEnabled() {
        animator.SetBool("Enabled", false);
    }

    void SetParameterActive() {
        animator.SetBool("Activated", true);

    }
    void UnSetParameterActive() {
        animator.SetBool("Activated", false);

    }

    void SetTriggerPerforming() {
        animator.SetTrigger("Performing");
    }

    void SetTriggerReset() {
        animator.SetTrigger("Reset");
    }
}
