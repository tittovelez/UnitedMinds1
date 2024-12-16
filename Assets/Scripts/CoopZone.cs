using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoopZone1 : MonoBehaviour
{
    public GameObject player1; // Referencia al Player 1
    public GameObject player2; // Referencia al Player 2
    public GameObject combinedPlayerPrefab; // Prefab del jugador combinado

    private GameObject combinedPlayer; // Instancia del jugador combinado
    private bool isPlayer1Inside = false; // Si Player 1 está en el área
    private bool isPlayer2Inside = false; // Si Player 2 está en el área

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player1)
        {
            isPlayer1Inside = true;
        }
        else if (other.gameObject == player2)
        {
            isPlayer2Inside = true;
        }

        // Si ambos jugadores están en el área
        if (isPlayer1Inside && isPlayer2Inside)
        {
            ActivateCoopMode();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player1)
        {
            isPlayer1Inside = false;
        }
        else if (other.gameObject == player2)
        {
            isPlayer2Inside = false;
        }

        // Si uno de los jugadores sale del área, desactivar el modo cooperativo
        if (!isPlayer1Inside || !isPlayer2Inside)
        {
            DeactivateCoopMode();
        }
    }

    private void ActivateCoopMode()
    {
        // Desactivar a los jugadores individuales
        player1.SetActive(false);
        player2.SetActive(false);

        // Crear el jugador combinado
        if (combinedPlayer == null)
        {
            combinedPlayer = Instantiate(combinedPlayerPrefab, transform.position, Quaternion.identity);
        }
    }

    private void DeactivateCoopMode()
    {
        // Desactivar el jugador combinado
        if (combinedPlayer != null)
        {
            Destroy(combinedPlayer);
            combinedPlayer = null;
        }

        // Reactivar a los jugadores individuales
        player1.SetActive(true);
        player2.SetActive(true);
    }
}
