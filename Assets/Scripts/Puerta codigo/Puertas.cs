using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    // Variables para configurar la puerta
    public GameObject door; // La puerta que queremos abrir
    public Vector3 openPosition; // Posici�n abierta de la puerta
    public float openSpeed = 2f; // Velocidad de apertura

    private Vector3 closedPosition; // Posici�n cerrada de la puerta
    private bool isOpening = false; // Estado de apertura

    void Start()
    {
        if (door != null)
        {
            closedPosition = door.transform.position; // Guardamos la posici�n inicial de la puerta
        }
        else
        {
            Debug.LogError("La puerta no est� asignada en el script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el jugador presiona el bot�n
        if (other.CompareTag("Player"))
        {
            isOpening = true; // Cambiamos el estado para abrir la puerta
        }
    }

    void Update()
    {
        if (isOpening && door != null)
        {
            // Movemos la puerta hacia la posici�n abierta
            door.transform.position = Vector3.Lerp(door.transform.position, openPosition, Time.deltaTime * openSpeed);

            // Verificamos si la puerta lleg� a la posici�n abierta
            if (Vector3.Distance(door.transform.position, openPosition) < 0.01f)
            {
                isOpening = false; // Detenemos el movimiento
            }
        }
    }
}
