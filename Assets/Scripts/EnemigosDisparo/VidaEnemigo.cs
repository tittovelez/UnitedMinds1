using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaEnemigo = 100; // Vida total del enemigo
    public Slider BarraVidaEnemigo; // Barra de vida del enemigo
    public GameObject objetoExistente; // Objeto que se activará cuando el enemigo muera

    void Start()
    {
        // Configura la barra de vida inicial
        if (BarraVidaEnemigo != null)
        {
            BarraVidaEnemigo.maxValue = vidaEnemigo;
            BarraVidaEnemigo.value = vidaEnemigo;
        }

        // Asegúrate de que el objeto que se activará está desactivado al inicio
        if (objetoExistente != null)
        {
            objetoExistente.SetActive(false);
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
        // Activa un objeto existente al morir
        if (objetoExistente != null)
        {
            objetoExistente.SetActive(true);
        }

        // Destruye el enemigo
        Destroy(gameObject);
    }
}