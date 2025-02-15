using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que genera cookies de perros y gatos
public class CookiesGenerator : MonoBehaviour
{
    // Variables de constantes
    [Header("Constants variables")]
    const int MAX_COOKIES = 15;
    const float TIME_BETWEEN_COOKIES = 2.0f;

    // Variables de lista de cookies
    [Header("Variables")]
    List<GameObject> cookiesList = new List<GameObject>();

    // Prefabs de cookies
    [Header("Prefabs")]
    public GameObject dogCookiePrefab, catCookiePrefab;

    // Referencias a los spawn de cookies
    public GameObject dogCookiesSpawn, catCookiesSpawn;

    // Método que se ejecuta al iniciar el script
    void Start()
    {
        // Inicia la generación de cookies            
        StartCoroutine(AddNewCookie());
    }

    // Método para generar una cookie
    private void GenerateCookie(GameObject cookiePrefab, GameObject goCookiesSpawn){
        // Obtiene el componente de CookiesSpawn
        CookiesSpawn cookiesSpawn = goCookiesSpawn.GetComponent<CookiesSpawn>();

        // Obtiene el tamaño del plano y una posición aleatoria en él
        Vector3 planeSize = cookiesSpawn.GetPlaneSize();
        Vector3 newRandomPosition = cookiesSpawn.GetRandomPositionOnPlane(planeSize);

        // Genera la cookie en la posición aleatoria
        GameObject newCookie = Instantiate(cookiePrefab, newRandomPosition, Quaternion.identity);

        // Añade la cookie a la lista de cookies
        cookiesList.Add(newCookie);
    }

    // Función que decide que cookie se genera en función de la cantidad de cookies de cada tipo
    private void CheckCookie(){
        // Variables de referencia a los prefabs de cookies y a los spawn de cookies
        GameObject selectedPrefab, cookiesSpawn;  

        // Obtiene el número de cookies de perros y gatos
        int numDogCookies = cookiesList.FindAll(cookie => cookie.tag == "DogCookie").Count;
        int numCatCookies = cookiesList.FindAll(cookie => cookie.tag == "CatCookie").Count;

        // Comprueba cuál de los dos tipos de cookies hay más y elige el que menos haya
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

        // Genera la cookie seleccionada
        GenerateCookie(selectedPrefab, cookiesSpawn);
    }

    // Corrutina para añadir una nueva cookie
    IEnumerator AddNewCookie(){
        // Comprueba si hay espacio para añadir una nueva cookie
        if(cookiesList.Count < MAX_COOKIES){
            CheckCookie();
        }

        // Espera un tiempo para añadir una nueva cookie
        yield return new WaitForSeconds(TIME_BETWEEN_COOKIES);

        // Vuelve a llamar a la corrutina para añadir una nueva cookie
        StartCoroutine(AddNewCookie());
    }

    // Método para eliminar una cookie de la lista
    public void RemoveCookie(GameObject cookie){
        cookiesList.Remove(cookie);
    }
}
