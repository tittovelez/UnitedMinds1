using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Vector3 offset;           // Offset para ajustar la posición del rayo
    public float rayLength = 0.5f;   // Longitud del rayo para detectar el suelo
    public LayerMask layerMask;      // Capa del suelo
    public bool grounded;            // ¿Está en el suelo?
    public KeyCode jumpKey = KeyCode.Space; // Tecla para saltar
    public float jumpForce = 5f;     // Fuerza del salto

    private Rigidbody rb;            // Referencia al Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
    }

    void Update()
    {
        CheckGrounded(); // Verificar si está en el suelo

        // Permitir salto solo si está en el suelo
        if (grounded && Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    void CheckGrounded()
    {
        RaycastHit hit;
        // Dibujar el rayo para visualizar la detección del suelo
        Debug.DrawRay(transform.position + offset, -transform.up * rayLength, Color.red);

        // Verificar si el rayo golpea el suelo
        if (Physics.Raycast(transform.position + offset, -transform.up, out hit, rayLength, layerMask))
        {
            grounded = true; // Está en el suelo
        }
        else
        {
            grounded = false; // No está en el suelo
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); // Aplicar fuerza de salto
        grounded = false; // Desactivar grounded hasta que vuelva al suelo
    }
}


