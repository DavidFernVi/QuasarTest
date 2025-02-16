using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que representa un spawn de cookies
public class CookiesSpawn : MonoBehaviour
{
    [Tooltip("Offset vertical para que las cookies no estén a ras de suelo")]
    public float offset = 1.0f;

    // Método que devuelve el tamaño del plano, considerando su escala
    public Vector3 GetPlaneSize()
    {
        // Comprobamos si el objeto tiene un MeshRenderer para obtener el tamaño del mesh
        if (TryGetComponent<MeshRenderer>(out MeshRenderer meshRenderer))
        {
            // Obtenemos el tamaño del mesh del plano y lo ajustamos a la escala
            Vector3 meshSize = meshRenderer.bounds.size;
            return new Vector3(meshSize.x, 0, meshSize.z);
        }
        else
        {
            // Si no tiene MeshRenderer, usamos la escala por defecto, que es 10x10
            Debug.LogWarning("El objeto no tiene un MeshRenderer. Se usará la escala por defecto.");
            return new Vector3(transform.localScale.x * 10f, 0, transform.localScale.z * 10f);
        }
    }

    // Método que devuelve una posición aleatoria en el plano. CustomOffset es opcional, por defecto se usa el offset del script
    public Vector3 GetRandomPositionOnPlane(Vector3 planeSize, float customOffset = -1f)
    {
        if (planeSize.x <= 0 || planeSize.z <= 0)
        {
            Debug.LogError("El tamaño del plano es inválido. No se puede generar una posición aleatoria.");
            return transform.position;
        }

        // Calcular posición aleatoria dentro de los límites del plano
        float randomX = Random.Range(-planeSize.x / 2, planeSize.x / 2);
        float randomZ = Random.Range(-planeSize.z / 2, planeSize.z / 2);

        // Determinar el offset a usar
        float finalOffset = customOffset >= 0 ? customOffset : offset;

        // Devolver la posición final en coordenadas globales
        return transform.position + new Vector3(randomX, finalOffset, randomZ);
    }
}