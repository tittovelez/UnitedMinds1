using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public int damageAmount = 20; // Cantidad de daño que quita el objeto mortal.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto tiene la etiqueta "Mortal"
        if (collision.CompareTag("Mortal"))
        {
            // Busca el componente PlayerHealth en este GameObject
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // Reduce la vida del jugador al tocar el objeto
                playerHealth.TakeDamage(damageAmount);
            }
            else
            {
                Debug.LogWarning("No se encontró el componente PlayerHealth en el jugador.");
            }
        }
    }
}


