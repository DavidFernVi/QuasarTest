using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCookie : MonoBehaviour, IInteractuableObj
{ 
    private CookiesController cookiesController;

    void Start()
    {
        cookiesController = FindObjectOfType<CookiesController>();
    }
    
    public void Interact()
    { 
        cookiesController.AddDogCookie(gameObject);
        Destroy(gameObject);
    }
}

