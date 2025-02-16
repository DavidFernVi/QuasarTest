using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que gestiona las cookies de perros y gatos
public class CookiesController : MonoBehaviour
{
    // Enum para diferenciar los tipos de cookies
    public enum CookieType { Dog, Cat }

    // Variables de cookies
    [Header("Number of Cookies")]
    public int numDogCookies = 0;
    public int numCatCookies = 0;
 
    // Variables de audio
    [Header("Audio Clips")]
    public AudioClip audioClipDog;
    public AudioClip audioClipCat;

    // Referencia a la UI
    [Header("Canvas UI")]
    public UICookies uiCookies;

    // Referencia al componente de audio
    private AudioSource audioSource;

    // Referencia al generador de cookies
    public CookiesGenerator cookiesGenerator;

    // Método que se ejecuta al iniciar el script
    private void Start()
    {
        // Obtiene el componente de audio con validación
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource no encontrado en " + gameObject.name);
        }

        // Validamos la referencia al generador de cookies
        if (cookiesGenerator == null)
        {
            Debug.LogError("CookiesGenerator no asignado en " + gameObject.name);
        }

        // Actualizamos la UI al inicio si existe
        uiCookies?.UpdateUI();
    }

    // Método genérico para añadir cookies
    public void AddCookie(GameObject cookie, CookieType type)
    {
        if (cookie == null) return;

        // Aumentamos el contador correspondiente
        switch (type)
        {
            case CookieType.Dog:
                numDogCookies++;
                PlaySound(audioClipDog);
                break;

            case CookieType.Cat:
                numCatCookies++;
                PlaySound(audioClipCat);
                break;
        }

        // Actualizamos la UI
        uiCookies?.UpdateUI();

        // Eliminamos la cookie de la escena
        cookiesGenerator?.RemoveCookie(cookie);
    }

    // Método para reproducir sonido si existe
    private void PlaySound(AudioClip clip)
    {
        // Reproducimos el sonido si existe
        if (clip != null && audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    // Métodos de acceso a las cookies
    public int GetDogCookies() => numDogCookies;
    public int GetCatCookies() => numCatCookies;
}