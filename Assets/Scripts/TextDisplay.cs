using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // O usa TMPro si trabajas con TextMeshPro
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public string[] texts; // Array de textos que se mostrarán
    public TMP_Text displayText; // Referencia al componente Text en la UI
    // Si usas TextMeshPro, usa TMP_Text en lugar de Text
    // public TMPro.TMP_Text displayText;

    private int currentIndex = 0; // Índice actual del texto
    private bool isPlayerNear = false; // Para detectar si el jugador está en rango

    void Update()
    {
        // Si el jugador está cerca y presiona la flecha derecha
        if (isPlayerNear && Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShowNextText();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true; // Activamos el control de texto
            currentIndex = 0; // Reiniciamos el índice al primer texto
            displayText.text = texts[currentIndex]; // Mostramos el primer texto
            displayText.gameObject.SetActive(true); // Asegúrate de que el texto esté visible
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false; // Salimos del rango
            displayText.gameObject.SetActive(false); // Ocultamos el texto
        }
    }

    void ShowNextText()
    {
        if (texts.Length == 0) return; // Si no hay textos, salir

        currentIndex++; // Avanzamos al siguiente texto
        if (currentIndex >= texts.Length) currentIndex = 0; // Reiniciar al inicio si llegamos al final
        displayText.text = texts[currentIndex]; // Actualizamos el texto en pantalla
    }
}
