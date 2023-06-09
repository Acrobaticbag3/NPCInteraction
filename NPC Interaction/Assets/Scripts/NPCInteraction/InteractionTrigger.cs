using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour {

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            float interactionRange = 2f;
            Collider[] colliderArr = Physics.OverlapSphere(transform.position, interactionRange);
            foreach (Collider collider in colliderArr) {
                if(collider.TryGetComponent(out InteractableNPC interactableNPC)) {
                    interactableNPC.Interact();
                }
            }
        }
    }

    public InteractableNPC GetInteractableObject() {
        List<InteractableNPC> interactableNPCList = new List<InteractableNPC>();
        float interactionRange = 2f;
        Collider[] colliderArr = Physics.OverlapSphere(transform.position, interactionRange);
        foreach (Collider collider in colliderArr) {
            if(collider.TryGetComponent(out InteractableNPC interactableNPC)) {
                interactableNPCList.Add(interactableNPC);
            }
        }

        InteractableNPC closestinteractableNPC = null;
        foreach(InteractableNPC interactableNPC in interactableNPCList) {
            if(closestinteractableNPC == null) {
                closestinteractableNPC = interactableNPC;
            } else if(Vector3.Distance(transform.position, interactableNPC.transform.position) < Vector3.Distance(transform.position, closestinteractableNPC.transform.position)) {
                closestinteractableNPC = interactableNPC;
            }
        } 
        return closestinteractableNPC;
    }
}
