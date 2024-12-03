using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Rigidbody))]
public class PersonMovement1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isActive = true; // Controla si el personaje está activo
    public float speed_forward = 4;
    public float speed_sideways = 3;
    public float speed_backwards = 2;
    public float speed_sprint = 8;
    public float speed_air = 1f;
    public float jumpForce = 1f; // Fuerza del salto

    public Vector3 direction;
    public Vector2 movement;
    public Vector3 velocity;
    private GroundDetector ground;
    private Rigidbody rb;

    private void Awake()
    {
        ground = GetComponent<GroundDetector>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        {
            if (!isActive) return; // Si no está activo, no se mueve

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

        }
        // Control de movimiento horizontal y vertical
        movement.y = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");

        // Limitar velocidad en diagonal
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        // Ajuste de velocidad de acuerdo a la dirección
        movement.x *= speed_sideways;

        if (movement.y > 0) // Avanzar hacia adelante
        {
            if (Input.GetButton("Sprint")) // Correr si se presiona el botón de correr
            {
                movement.y *= speed_sprint;
            }
            else
            {
                movement.y *= speed_forward;
            }
        }
        else // Retroceder
        {
            movement.y *= speed_backwards;
        }

        // Reducir velocidad en el aire
        if (!ground.grounded)
        {
            movement *= speed_air;
        }

        // Movimiento basado en la orientación del objeto
        transform.position += transform.forward * movement.y * Time.deltaTime + transform.right * movement.x * Time.deltaTime;

        // Comprobar y realizar el salt
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity += (Vector3.up * jumpForce);
        }
    }
}
