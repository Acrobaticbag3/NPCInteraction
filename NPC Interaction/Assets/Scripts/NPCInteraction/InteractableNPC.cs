using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour {
    [SerializeField] private string interactionText;

    public void Interact() {
        Debug.Log("Interacting!");
    }

    public string GetInteractionText() {
        return interactionText;
    }
}
