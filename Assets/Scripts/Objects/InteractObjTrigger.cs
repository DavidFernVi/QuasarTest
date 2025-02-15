using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interfaz que define un método de interacción
public class InteractObjTrigger : MonoBehaviour
{
    // Referencia al objeto interactuable
    private IInteractuableObj interactable; 

    // Método que se ejecuta al iniciar el script
    void Start()
    {
        // Obtiene el componente interactuable del objeto
        interactable = GetComponent<IInteractuableObj>();
    }

    // Método que se ejecuta al entrar en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Interactúa con el objeto
            interactable.Interact();
        }
    }
}
