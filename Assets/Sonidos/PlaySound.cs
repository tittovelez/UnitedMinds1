using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource asignado en el Inspector

    void Update()
    {
        // Detecta cuando se presiona el bot�n izquierdo del rat�n
        if (Input.GetMouseButtonDown(0))
        {
            if (audioSource != null) // Aseg�rate de que el AudioSource est� asignado
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

