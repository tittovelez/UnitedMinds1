using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPoint : MonoBehaviour
{
    private int playersInArea = 0; // Contador de jugadores en el �rea
    public string playerTag = "Player"; // El tag que comparten los jugadores

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra tiene el tag configurado
        if (other.CompareTag(playerTag))
        {
            playersInArea++;
            CheckInteraction();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que sale tiene el tag configurado
        if (other.CompareTag(playerTag))
        {
            playersInArea--;
        }
    }

    void CheckInteraction()
    {
        // Comprueba si ambos jugadores est�n en el �rea
        if (playersInArea >= 2) // Se asume que tienes exactamente 2 jugadores
        {
            TriggerInteraction();
        }
    }

    void TriggerInteraction()
    {
        // Aqu� va el c�digo para ejecutar la interacci�n
        Debug.Log("�Ambos jugadores est�n en el �rea! Interacci�n activada.");
        // Por ejemplo, puedes activar animaciones, abrir una puerta, etc.
    }
}


