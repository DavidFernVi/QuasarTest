using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookiesGenerator : MonoBehaviour
{
    [Header("Constants variables")]
    const int MAX_COOKIES = 15;
    const float TIME_BETWEEN_COOKIES = 2.0f;

    [Header("Variables")]
    List<GameObject> cookiesList = new List<GameObject>();

    [Header("Prefabs")]
    public GameObject dogCookiePrefab;
    public GameObject catCookiePrefab;


    void Start()
    {
        StartCoroutine(AddNewCookie());
    }

    private void GenerateCookie(GameObject cookiePrefab){
        GameObject newCookie = Instantiate(cookiePrefab, new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f)), Quaternion.identity);
        cookiesList.Add(newCookie);
    }

    // Función que decide que cookie se genera en función de la cantidad de cookies de cada tipo
    private void CheckCookie(){
        GameObject selectedPrefab;

        int numDogCookies = cookiesList.FindAll(cookie => cookie.tag == "DogCookie").Count;
        int numCatCookies = cookiesList.FindAll(cookie => cookie.tag == "CatCookie").Count;

        if(numDogCookies < numCatCookies){
            selectedPrefab = dogCookiePrefab;
        }else if(numDogCookies > numCatCookies){
            selectedPrefab = catCookiePrefab;
        }else{
            selectedPrefab = Random.Range(0, 2) == 0 ? dogCookiePrefab : catCookiePrefab;
        }   

        GenerateCookie(selectedPrefab);
    }

    IEnumerator AddNewCookie(){
        if(cookiesList.Count < MAX_COOKIES){
            CheckCookie();
        }
        yield return new WaitForSeconds(TIME_BETWEEN_COOKIES);
        StartCoroutine(AddNewCookie());
    }

    public void RemoveCookie(GameObject cookie){
        cookiesList.Remove(cookie);
    }
}
