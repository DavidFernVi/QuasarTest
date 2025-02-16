using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Clase que gestiona la interfaz de usuario relacionada con las cookies
public class UICookies : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dogCookiesText;
    public TextMeshProUGUI catCookiesText;

    [Header("References")]
    public CookiesController cookiesController;

    // Valores anteriores para evitar actualizaciones innecesarias
    private int previousDogCookies = -1;
    private int previousCatCookies = -1;

    // Método que se ejecuta al iniciar el script
    private void Start()
    {
        // Comprobamos que las referencias estén asignadas
        if (cookiesController == null)
        {
            Debug.LogError("CookiesController no asignado en " + gameObject.name);
            return;
        }

        // Comprobamos que los TextMeshProUGUI estén asignados
        if (dogCookiesText == null || catCookiesText == null)
        {
            Debug.LogError("Algún TextMeshProUGUI no está asignado en " + gameObject.name);
            return;
        }

        // Actualiza la interfaz al inicio
        UpdateUI();
    }

    // Método para actualizar los textos de las cookies en la UI
    public void UpdateUI()
    {
        // Obtenemos los valores actuales de cookies
        int currentDogCookies = cookiesController.GetDogCookies();
        int currentCatCookies = cookiesController.GetCatCookies();

        // Solo actualizamos el texto si el valor ha cambiado
        if (currentDogCookies != previousDogCookies)
        {
            dogCookiesText.text = $"{currentDogCookies}";
            previousDogCookies = currentDogCookies;
        }

        if (currentCatCookies != previousCatCookies)
        {
            catCookiesText.text = $"{currentCatCookies}";
            previousCatCookies = currentCatCookies;
        }
    }
}