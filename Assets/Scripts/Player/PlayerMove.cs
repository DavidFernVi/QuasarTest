using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control de movimiento y rotación del jugador
[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    // Referencias
    [Header("References")]
    [Tooltip("Cabeza del jugador para controlar la rotación vertical")]
    public Transform head;

    // Configuraciones
    [Header("Movement Settings")]
    [Tooltip("Velocidad de movimiento del jugador")]
    [Range(1f, 20f)]
    public float walkSpeed = 5f;

    [Header("Look Settings")]
    [Tooltip("Sensibilidad del ratón")]
    [Range(50f, 500f)]
    public float mouseSensitivity = 200f;

    // Variables privadas
    private Rigidbody rb;
    private float verticalRotation = 0f;

    // Inicialización al inicio del juego
    private void Awake()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Inicialización al inicio del script
    private void Start()
    {
        // Ocultamos y bloqueamos el cursor para el control de cámara
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Lógica de entrada y rotación
    private void Update()
    {
        RotateCamera();
    }

    // Movimiento del jugador. Usamos FixedUpdate para físicas más precisas
    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Método para mover al jugador
    private void MovePlayer()
    {
        // Capturamos la entrada del jugador. Usamos GetAxisRaw para evitar problemas con la sensibilidad del mando
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        // Calculamos la dirección relativa a la orientación del jugador
        Vector3 moveDirection = (transform.right * moveX + transform.forward * moveZ).normalized;

        // Aplicamos la velocidad sin afectar el eje Y
        Vector3 targetVelocity = new Vector3(moveDirection.x * walkSpeed, rb.velocity.y, moveDirection.z * walkSpeed);
        rb.velocity = targetVelocity;
    }

    // Método para rotar la cámara
    private void RotateCamera()
    {
        // Capturamos la entrada del ratón
        // Usamos GetAxisRaw para evitar problemas con la sensibilidad del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación horizontal del jugador
        transform.Rotate(Vector3.up * mouseX);

        // Rotación vertical de la cámara
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Aplicamos la rotación solo a la cabeza
        head.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
