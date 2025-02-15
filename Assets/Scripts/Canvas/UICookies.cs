using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Clase que gestiona la interfaz de usuario relacionada con las cookies de perros y gatos
public class UICookies : MonoBehaviour
{
    // Referencias a los elementos de texto en la UI para mostrar las cookies
    [Header("UI References")]
    public TextMeshProUGUI dogCookiesText, catCookiesText;

    // Referencia al controlador que gestiona la lógica de las cookies
    [Header("References")]
    public CookiesController cookiesController;

    // Método que se ejecuta al iniciar el script
    private void Start()
    {
        // Actualiza la interfaz de usuario con los valores actuales
        UpdateUI();
    }

    // Método para actualizar los textos de las cookies en la UI
    public void UpdateUI()
    {
        // Muestra el número de cookies de perros obteniéndolo del controlador
        dogCookiesText.text = cookiesController.GetDogCookies().ToString();

        // Muestra el número de cookies de gatos obteniéndolo del controlador
        catCookiesText.text = cookiesController.GetCatCookies().ToString();
    }
}