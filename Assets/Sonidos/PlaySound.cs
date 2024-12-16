using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource asignado en el Inspector

    void Update()
    {
        // Detecta cuando se presiona el botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            if (audioSource != null) // Asegúrate de que el AudioSource esté asignado
            {
                audioSource.Play(); // Reproducir el sonido
            }
            else
            {
                Debug.LogWarning("AudioSource no asignado al script.");
            }
        }
    }
}

