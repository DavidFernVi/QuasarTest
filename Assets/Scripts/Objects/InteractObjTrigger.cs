using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjTrigger : MonoBehaviour
{
    private IInteractuableObj interactable; 

    void Start()
    {
        interactable = GetComponent<IInteractuableObj>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.Interact();
        }
    }
}
