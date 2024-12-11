using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public float healAmount = 10f; // Cantidad de vida que cura
    public float damageAmount = 10f; // Cantidad de vida que quita
    public bool isHealing = true; // Define si este objeto cura (true) o hace daño (false)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Intentar obtener el componente PlayerHealth del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                if (isHealing)
                {
                    playerHealth.Heal(healAmount); // Curar al jugador
                    Debug.Log("El jugador fue curado: +" + healAmount + " de vida.");
                }
                else
                {
                    playerHealth.TakeDamage(damageAmount); // Hacer daño al jugador
                    Debug.Log("El jugador recibió daño: -" + damageAmount + " de vida.");
                }
            }

            Destroy(gameObject); // Destruir el objeto después de la interacción
        }
    }
}
