using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public DoorController door; // Referencia a la puerta
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player")) // Verifica que el objeto que activa sea el jugador
        {
            door.OpenDoor(); // Llama a la función para hacer que la puerta desaparezca
        }
    }
}

