using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona las cookies de perros y gatos
public class CookiesController : MonoBehaviour
{
    // Número de cookies de perros y gatos
    [Header("Number of Cookies")]
    public int numDogCookies = 0;
    public int numCatCookies = 0;

    // Clips de audio para cuando se obtienen cookies de perros y gatos
    [Header("Audio Clips")]
    public AudioClip audioClipDog, audioClipCat;
    
    // Referencia a la interfaz de usuario de las cookies
    [Header("Canvas UI")]
    public UICookies uiCookies;

    // Referencia al componente de audio
    private AudioSource audioSource;

    // Referencia al generador de cookies
    public CookiesGenerator cookiesGenerator;

    // Método que se ejecuta al iniciar el script
    private void Start()
    {
        // Obtiene el componente de audio
        audioSource = GetComponent<AudioSource>();
    }

    // Método para añadir una cookie de perro
    public void AddDogCookie(GameObject cookie)
    {
        // Aumenta el número de cookies de perros
        numDogCookies++;

        // Actualiza la interfaz de usuario
        uiCookies.UpdateUI();

        // Reproduce el clip de audio de la cookie de perro
        if (audioClipDog != null)
        {
            audioSource.Stop();
            audioSource.clip = audioClipDog;
            audioSource.Play();
        }

        // Elimina la cookie de la escena
        cookiesGenerator.RemoveCookie(cookie);
    }

    // Método para añadir una cookie de gato
    public void AddCatCookie(GameObject cookie)
    {
        // Aumenta el número de cookies de gatos                            
        numCatCookies++;

        // Actualiza la interfaz de usuario
        uiCookies.UpdateUI();

        // Reproduce el clip de audio de la cookie de gato
        if (audioClipCat != null)
        {
            audioSource.Stop();
            audioSource.clip = audioClipCat;
            audioSource.Play();
        }

        // Elimina la cookie de la escena
        cookiesGenerator.RemoveCookie(cookie);
    }

    // Método para obtener el número de cookies de perros
    public int GetCatCookies()
    {
        return numCatCookies;
    }

    // Método para obtener el número de cookies de gatos
    public int GetDogCookies()
    {
        return numDogCookies;
    }
}
