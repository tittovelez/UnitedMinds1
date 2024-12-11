using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar; // La barra de vida
    public float maxHealth = 100f; // Salud máxima
    public float startingHealth = 50f; // Salud inicial
    private float currentHealth; // Salud actual

    void Start()
    {
        currentHealth = Mathf.Clamp(startingHealth, 0, maxHealth); // Configurar salud inicial
        UpdateHealthBar(); // Actualizar la barra de vida
    }

    public void Heal(float amount)
    {
        currentHealth += amount; // Aumentar la salud actual
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Limitar entre 0 y la salud máxima
        UpdateHealthBar(); // Actualizar la barra de vida
        Debug.Log("El jugador fue curado: +" + amount + " de salud.");
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount; // Reducir la salud actual
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Limitar para que no sea menor a 0
        UpdateHealthBar(); // Actualizar la barra de vida
        Debug.Log("El jugador recibió daño: -" + amount + " de salud.");

        if (currentHealth <= 0)
        {
            Die(); // Llamar al método de muerte si la salud llega a 0
        }
    }

    private void Die()
    {
        Debug.Log("¡El jugador ha muerto!");
        // Aquí puedes añadir lógica adicional, como reiniciar el nivel o mostrar Game Over
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth; // Actualizar el valor de la barra de vida
        }
    }
}




