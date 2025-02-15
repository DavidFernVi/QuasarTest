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
    public GameObject dogCookiePrefab, catCookiePrefab;

    public GameObject dogCookiesSpawn, catCookiesSpawn;


    void Start()
    {
        StartCoroutine(AddNewCookie());
    }

    private void GenerateCookie(GameObject cookiePrefab, GameObject goCookiesSpawn){ 
        CookiesSpawn cookiesSpawn = goCookiesSpawn.GetComponent<CookiesSpawn>();
        Vector3 planeSize = cookiesSpawn.GetPlaneSize();
        Vector3 newRandomPosition = cookiesSpawn.GetRandomPositionOnPlane(planeSize);
        GameObject newCookie = Instantiate(cookiePrefab, newRandomPosition, Quaternion.identity);
        cookiesList.Add(newCookie);
    }

    // Función que decide que cookie se genera en función de la cantidad de cookies de cada tipo
    private void CheckCookie(){
        GameObject selectedPrefab, cookiesSpawn;

        int numDogCookies = cookiesList.FindAll(cookie => cookie.tag == "DogCookie").Count;
        int numCatCookies = cookiesList.FindAll(cookie => cookie.tag == "CatCookie").Count;

        if(numDogCookies < numCatCookies){
            selectedPrefab = dogCookiePrefab;
            cookiesSpawn = dogCookiesSpawn;
        }else if(numDogCookies > numCatCookies){
            selectedPrefab = catCookiePrefab;
            cookiesSpawn = catCookiesSpawn;
        }else{
            // Si están iguales, elegimos aleatoriamente
            if (Random.Range(0, 2) == 0)
            {
                selectedPrefab = dogCookiePrefab;
                cookiesSpawn = dogCookiesSpawn;
            }
            else
            {
                selectedPrefab = catCookiePrefab;
                cookiesSpawn = catCookiesSpawn;
            }
        }   

        GenerateCookie(selectedPrefab, cookiesSpawn);
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
