using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    private float rotationSpeed = 50.0f;
    private float currentRotation = 0.0f;

    void Update()
    {
        currentRotation += rotationSpeed * Time.deltaTime;

        currentRotation = Mathf.Repeat(currentRotation, 360);

        transform.rotation = Quaternion.Euler(0, currentRotation, 0);
    }
}
