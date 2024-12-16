using UnityEngine;

public class WinGame12 : MonoBehaviour
{
    public GameObject winCanvas;
    // Método que detecta cuando entra en contacto con un trigger
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto tiene la etiqueta "Collectible"
        if (other.CompareTag("Collectible"))
        {
            // Destruye el objeto recogido
            Destroy(other.gameObject);

            // Llama al método para ganar el juego
            WinGame();
        }
    }

    // Método para manejar la victoria
    void WinGame()
    {
        // Muestra un mensaje en la consola
        Debug.Log("¡Has ganado el juego!");
        winCanvas.SetActive(true);

        // Aquí puedes añadir otras acciones, como cargar otra escena
    }
}

