using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas

public class GameController1 : MonoBehaviour
{
    // Este script se coloca en el objeto que aparece cuando el enemigo es derrotado

    // Método que se ejecuta cuando el jugador colisiona con el objeto
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tiene el tag "Player"
        {
            // Cargar la escena de "Has Ganado"
            SceneManager.LoadScene("HasGanadoScene");
        }
    }
}

