using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Rigidbody))]
public class FirstPersonMovement : MonoBehaviour
{
    public float speed_forward = 4;
    public float speed_sideways = 3;
    public float speed_backwards = 2;
    public float speed_sprint = 8;
    public float speed_air = 1f;
    public Vector2 movement;
    public Vector3 velocity;
    private Vector3 desiredvelocity;
    Vector3 lastPosition;

    private GroundDetector ground;
    private Rigidbody rb;

    private void Awake()
    {
        ground = GetComponent<GroundDetector>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        movement.y = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");
        if (movement.magnitude > 1) //Si el input es con teclado, es posible que en diagonal vaya más rápido que de frente, limitamos el input del jugador.
        {
            movement = movement.normalized;
        }

        //La velocidad lateral siempre es la misma
        movement.x *= speed_sideways;

        //Si el jugador va hacia adelante
        if (movement.y > 0)
        {
            if (Input.GetButton("Sprint")) //Aplicamos otra velocidad cuando el jugador esté corriendo. Esta velocidad se aplica solo cuando el jugador vaya hacia adelante
            {
                movement.y *= speed_sprint;
            }
            else
            {
                movement.y *= speed_forward;
            }
        }
        else // Si el jugador va hacia atrás
        {
            movement.y *= speed_backwards;
        }

        if (!ground.grounded)//Cuando el jugador está en el aire, su velocidad es distinta
        {
            movement *= speed_air;
        }
        transform.position += transform.forward * movement.y * Time.deltaTime + transform.right * movement.x * Time.deltaTime;
    }
    void LateUpdate() //Calculo de la velocidad real para la animación
    {
        desiredvelocity = transform.InverseTransformDirection(((transform.position - lastPosition) / Time.deltaTime) + rb.velocity);
        velocity = Vector3.Lerp(velocity, desiredvelocity, Time.deltaTime * 5);
        lastPosition = transform.position;
    }
}
