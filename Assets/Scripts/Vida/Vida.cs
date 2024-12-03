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
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }
    }
}



