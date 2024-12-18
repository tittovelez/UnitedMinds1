using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Rigidbody))]
public class PersonMovement2 : MonoBehaviour
{
    public AudioSource jumpSound; // AudioSource para el sonido del salto
    public float moveSpeed = 5f;
    public bool isActive = true; // Controla si el personaje está activo
    public float speed_forward = 4;
    public float speed_sideways = 3;
    public float speed_backwards = 2;
    public float speed_sprint = 8;
    public float speed_air = 1f;
    public float jumpForce = 5f; // Fuerza del salto

    private Vector2 movement;
    private Rigidbody rb;
    private GroundDetector ground;

    private bool canJump = false; // Controla si el personaje puede saltar

    private void Awake()
    {
        ground = GetComponent<GroundDetector>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isActive) return; // Si no está activo, no se mueve

        // Lectura del input
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Limitar velocidad en diagonal
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        // Ajuste de velocidad según dirección
        float currentSpeed = movement.y > 0
            ? (Input.GetButton("Sprint") ? speed_sprint : speed_forward)
            : speed_backwards;

        movement.x *= speed_sideways;
        movement.y *= currentSpeed;

        // Reducir velocidad en el aire
        if (!ground.grounded)
        {
            movement *= speed_air;
        }

        // Movimiento basado en física
        Vector3 moveDirection = transform.forward * movement.y + transform.right * movement.x;
        rb.MovePosition(rb.position + moveDirection * Time.deltaTime);

        // Saltar solo si está en el suelo
        if (ground.grounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Realiza el salto
        jumpSound.Play(); // Reproduce el sonido del salto
        canJump = false; // Bloquear salto temporalmente
    }

    private void FixedUpdate()
    {
        // Actualizar si puede saltar dependiendo de si está en el suelo
        if (ground.grounded)
        {
            canJump = true;
        }
        else
        {
            canJump = false; // Bloquear salto si no está tocando el suelo
        }
    }
}

