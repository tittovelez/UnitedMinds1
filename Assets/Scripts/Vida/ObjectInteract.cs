using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public float healAmount = 10f; // Daño que este objeto causa al jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Intentar obtener el componente PlayerHealth del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount); // Reducir la vida del jugador
            }

            Destroy(gameObject); // Destruir el objeto
        }
    }
}



