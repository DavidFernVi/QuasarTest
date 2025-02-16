using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para rotar un objeto en cualquier eje
public class ObjectRotation : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Velocidad de rotación en grados por segundo")]
    [SerializeField] private float rotationSpeed = 50.0f;

    [Tooltip("Eje de rotación del objeto")]
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    [Tooltip("¿Debe rotar automáticamente?")]
    [SerializeField] private bool isRotating = true;

    // Actualización
    private void Update()
    {
        // Si la rotación está habilitada, rotamos el objeto
        if (isRotating)
        {
            RotateObject();
        }
    }

    // Método para rotar el objeto
    private void RotateObject()
    {
        // Aplicamos la rotación directamente
        transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);
    }

    // Métodos públicos para controlar la rotación
    public void StartRotation() => isRotating = true;
    public void StopRotation() => isRotating = false;
    public void SetRotationSpeed(float speed) => rotationSpeed = speed;
    public void SetRotationAxis(Vector3 axis) => rotationAxis = axis;
}