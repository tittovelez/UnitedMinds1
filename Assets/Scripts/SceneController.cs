using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // M�todo para reiniciar el nivel
    public void RestartLevel()
    {
        Time.timeScale = 1; // Restaurar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recargar la escena actual
    }

    // M�todo para volver al men� principal
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1; // Restaurar el tiempo
        SceneManager.LoadScene("MenuPrincipal"); // Cambiar a la escena del men� principal
    }
}

