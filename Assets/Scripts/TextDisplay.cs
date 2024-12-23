using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // O usa TMPro si trabajas con TextMeshPro
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public string[] texts; // Array de textos que se mostrar�n
    public TMP_Text displayText; // Referencia al componente Text en la UI
    // Si usas TextMeshPro, usa TMP_Text en lugar de Text
    // public TMPro.TMP_Text displayText;

    private int currentIndex = 0; // �ndice actual del texto
    private bool isPlayerNear = false; // Para detectar si el jugador est� en rango

    void Update()
    {
        // Si el jugador est� cerca y presiona la flecha derecha
        if (isPlayerNear && Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShowNextText();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            currentIndex = 0; // Reiniciar al primer texto.
            if (texts.Length > 0)
            {
                displayText.text = texts[currentIndex]; // Mostrar el primer texto.
                displayText.gameObject.SetActive(true); // Asegurarse de que el texto est� visible.
            }
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
        if (texts.Length == 0) return; // Salir si no hay textos.

        currentIndex++; // Avanzar al siguiente texto.

        if (currentIndex >= texts.Length)
        {
            displayText.gameObject.SetActive(false); // Ocultar el texto.
            isPlayerNear = false; // Opcional: desactivar la interacci�n.
        }
        else
        {
            displayText.text = texts[currentIndex]; // Mostrar el siguiente texto.
        }
    }

}
