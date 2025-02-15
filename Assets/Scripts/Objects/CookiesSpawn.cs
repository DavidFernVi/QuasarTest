using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que representa un spawn de cookies
public class CookiesSpawn : MonoBehaviour
{
    // Variable de offset para que las cookies no estén a ras de suelo
    public float offset = 1.0f;

    // Método que devuelve el tamaño del plano
    public Vector3 GetPlaneSize()
    {
        // El plano de Unity tiene una escala base de 10x10, así que multiplicamos por su escala
        Vector3 size = new Vector3(
            transform.localScale.x * 10f,
            0,
            transform.localScale.z * 10f
        );

        return size;
    }

    // Método que devuelve una posición aleatoria en el plano
    public Vector3 GetRandomPositionOnPlane(Vector3 planeSize)
    {
        // Calcular posición aleatoria dentro de los límites del plano
        float randomX = Random.Range(-planeSize.x / 2, planeSize.x / 2);
        float randomZ = Random.Range(-planeSize.z / 2, planeSize.z / 2);

        // Devolver la posición final en coordenadas globales
        // El offset lo añadimos para que no estén a ras de suelo
        return transform.position + new Vector3(randomX, transform.position.y + offset, randomZ);
    }
}
