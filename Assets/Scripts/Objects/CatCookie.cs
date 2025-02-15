using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCookie : MonoBehaviour, IInteractuableObj
{
    private CookiesController cookiesController;

    void Start()
    {
        cookiesController = FindObjectOfType<CookiesController>();
    }
    
    public void Interact()
    {
        cookiesController.AddCatCookie(gameObject);
        Destroy(gameObject);
    }
}
