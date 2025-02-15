using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que representa una cookie de perro
public class DogCookie : MonoBehaviour, IInteractuableObj
{ 
    // Referencia al controlador de cookies
    private CookiesController cookiesController;

    // Método que se ejecuta al iniciar el script
    void Start()
    {
        // Obtiene el controlador de cookies
        cookiesController = FindObjectOfType<CookiesController>();
    }
    
    // Método que se ejecuta al interactuar con la cookie
    public void Interact()
    { 
        // Añade una cookie de perro y elimina la cookie de la escena
        cookiesController.AddDogCookie(gameObject);
        Destroy(gameObject);
    }
}

