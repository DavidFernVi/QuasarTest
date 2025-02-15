using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para rotar un objeto periódicamente
public class ObjectRotation : MonoBehaviour
{
    // Configuraciones de rotación
    [Header("Rotation Settings")]
    private float rotationSpeed = 50.0f;
    private float currentRotation = 0.0f;

    // Actualización
    void Update()
    {
        // Rotamos el objeto
        currentRotation += rotationSpeed * Time.deltaTime;

        // Mantenemos el ángulo entre 0 y 360
        currentRotation = Mathf.Repeat(currentRotation, 360);

        // Aplicamos la rotación
        transform.rotation = Quaternion.Euler(0, currentRotation, 0);
    }
}
