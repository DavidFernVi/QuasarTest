using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Transform head;

    [Header("Configurations")]
    public float walkSpeed;
    public float mouseSensitivity;

    private float verticalRotation = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        MoverPlayer();
    }

    void Update()
    {
        RotatePlayer();
    }

    private void MoverPlayer()
    {
        // Capturamos la entrada del jugador
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculamos la dirección relativa a la cámara
        Vector3 moveDirection = (transform.right * moveX + transform.forward * moveZ).normalized;
        moveDirection.y = 0; // Evitamos movimiento vertical involuntario

        // Aplicamos la velocidad manteniendo el eje Y para el salto
        Vector3 targetVelocity = moveDirection * walkSpeed;
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z);
    }

    private void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;	
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        Vector3 newRotation = new Vector3(0, mouseX, 0);
        transform.Rotate(newRotation); // Giramos el cuerpo del jugador

        verticalRotation -= mouseY; // Invertimos el eje Y para un control natural
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limitamos la rotación vertical

        // Aplicamos la rotación solo a la cabeza
        head.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
