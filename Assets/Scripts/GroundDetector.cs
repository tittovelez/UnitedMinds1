using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Vector3 offset;           // Offset para ajustar la posici�n del rayo
    public float rayLength = 0.5f;   // Longitud del rayo para detectar el suelo
    public LayerMask layerMask;      // Capa del suelo
    public bool grounded;            // �Est� en el suelo?
    public KeyCode jumpKey = KeyCode.Space; // Tecla para saltar
    public float jumpForce = 5f;     // Fuerza del salto

    private Rigidbody rb;            // Referencia al Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
    }

    void Update()
    {
        CheckGrounded(); // Verificar si est� en el suelo

        // Permitir salto solo si est� en el suelo
        if (grounded && Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    void CheckGrounded()
    {
        RaycastHit hit;
        // Dibujar el rayo para visualizar la detecci�n del suelo
        Debug.DrawRay(transform.position + offset, -transform.up * rayLength, Color.red);

        // Verificar si el rayo golpea el suelo
        if (Physics.Raycast(transform.position + offset, -transform.up, out hit, rayLength, layerMask))
        {
            grounded = true; // Est� en el suelo
        }
        else
        {
            grounded = false; // No est� en el suelo
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); // Aplicar fuerza de salto
        grounded = false; // Desactivar grounded hasta que vuelva al suelo
    }
}


