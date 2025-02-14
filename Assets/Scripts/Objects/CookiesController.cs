using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookiesController : MonoBehaviour
{
    [Header("Number of Cookies")]
    public int numDogCookies = 0;
    public int numCatCookies = 0;

    [Header("Audio Clips")]
    public AudioClip audioClipDog, audioClipCat;

    [Header("Canvas UI")]
    public UICookies uiCookies;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AddDogCookie()
    {
        numDogCookies++;

        uiCookies.UpdateUI();

        if (audioClipDog != null)
        {
            audioSource.Stop();
            audioSource.clip = audioClipDog;
            audioSource.Play();
        }
    }

    public void AddCatCookie()
    {
        numCatCookies++;

        uiCookies.UpdateUI();

        if (audioClipCat != null)
        {
            audioSource.Stop();
            audioSource.clip = audioClipCat;
            audioSource.Play();
        }
    }

    public int GetCatCookies()
    {
        return numCatCookies;
    }

    public int GetDogCookies()
    {
        return numDogCookies;
    }
}
