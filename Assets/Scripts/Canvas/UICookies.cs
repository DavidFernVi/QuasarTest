using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICookies : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI dogCookiesText, catCookiesText;

    public CookiesController cookiesController;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        dogCookiesText.text = cookiesController.GetDogCookies().ToString();
        catCookiesText.text = cookiesController.GetCatCookies().ToString();
    }
}
