using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cambiar o recargar escenas

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar; // La barra de vida
    public GameObject gameOverPanel; // Panel de Game Over en la UI
    public float maxHealth = 100f; // Salud máxima
    public float startingHealth = 50f; // Salud inicial
    private float currentHealth; // Salud actual

    void Start()
    {
        currentHealth = Mathf.Clamp(startingHealth, 0, maxHealth); // Configurar salud inicial
        UpdateHealthBar(); // Actualizar la barra de vida

        // Asegurarse de que el panel de Game Over esté desactivado
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
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

        // Mostrar el panel de "DIE" (o Game Over)
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Activar el panel
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Detener el tiempo (pausar el juego)
        Time.timeScale = 0;
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth; // Actualizar el valor de la barra de vida
        }
    }

    // Método para reiniciar el nivel
    /*public void RestartLevel()
    {
        Time.timeScale = 1; // Restaurar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recargar la escena actual
    }*/

    // Método para volver al menú principal
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1; // Restaurar el tiempo
        SceneManager.LoadScene("MenuPrincipal"); // Cambiar a la escena del menú principal
    }
}





