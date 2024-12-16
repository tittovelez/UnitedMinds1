using UnityEngine;

public class WinGame12 : MonoBehaviour
{
    public GameObject winCanvas;
    // M�todo que detecta cuando entra en contacto con un trigger
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto tiene la etiqueta "Collectible"
        if (other.CompareTag("Collectible"))
        {
            // Destruye el objeto recogido
            Destroy(other.gameObject);

            // Llama al m�todo para ganar el juego
            WinGame();
        }
    }

    // M�todo para manejar la victoria
    void WinGame()
    {
        // Muestra un mensaje en la consola
        Debug.Log("�Has ganado el juego!");
        winCanvas.SetActive(true);

        // Aqu� puedes a�adir otras acciones, como cargar otra escena
    }
}

