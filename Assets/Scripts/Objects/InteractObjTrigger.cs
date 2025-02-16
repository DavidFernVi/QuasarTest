using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que activa la interacción al entrar en un trigger
public class InteractObjTrigger : MonoBehaviour
{
    [Tooltip("Etiqueta del objeto que puede activar la interacción")]
    public string targetTag = "Player";

    // Referencia al objeto interactuable
    private IInteractuableObj interactable;

    // Método que se ejecuta al iniciar la escena
    private void Awake()
    {
        // Intenta obtener el componente interactuable
        interactable = GetComponent<IInteractuableObj>();

        // Validamos si el objeto tiene la interfaz
        if (interactable == null)
        {
            Debug.LogWarning($"El objeto {gameObject.name} no tiene un componente que implemente IInteractuableObj.");
        }
    }

    // Método que se ejecuta al entrar en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra tiene la etiqueta correcta
        if (other.CompareTag(targetTag))
        {
            // Verificar que interactable no sea nulo antes de usarlo
            if (interactable != null)
            {
                interactable.Interact();
            }
            else
            {
                Debug.LogError($"Intento de interactuar con un objeto sin IInteractuableObj: {gameObject.name}");
            }
        }
    }
}