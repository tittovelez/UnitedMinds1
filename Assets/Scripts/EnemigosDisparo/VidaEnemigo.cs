using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaEnemigo = 100; // Vida total del enemigo
    public Slider BarraVidaEnemigo; // Barra de vida del enemigo
    public GameObject objetoAlMorir; // Objeto que aparecerá cuando el enemigo muera

    void Start()
    {
        // Configura la barra de vida inicial
        if (BarraVidaEnemigo != null)
        {
            BarraVidaEnemigo.maxValue = vidaEnemigo;
            BarraVidaEnemigo.value = vidaEnemigo;
        }
    }

    void Update()
    {
        // Actualiza la barra de vida si existe
        if (BarraVidaEnemigo != null)
        {
            BarraVidaEnemigo.value = vidaEnemigo;
        }

        // Verifica si el enemigo ha muerto
        if (vidaEnemigo <= 0)
        {
            Morir();
        }
    }

    public void RecibirDaño(int damage)
    {
        // Reduce la vida del enemigo
        vidaEnemigo -= damage;
    }

    void Morir()
    {
        // Aparece un objeto al morir en la posición del enemigo
        if (objetoAlMorir != null)
        {
            Instantiate(objetoAlMorir, transform.position, Quaternion.identity);
        }

        // Destruye el enemigo
        Destroy(gameObject);
    }
}



