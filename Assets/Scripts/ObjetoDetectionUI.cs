using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class ObjectDetectionUI : MonoBehaviour
{
    public TextMeshProUGUI textObject; // Arrastra aqu� el texto UI desde el inspector
    public string targetTag = "Player"; // Cambia este Tag seg�n el objeto que desees detectar

    private void Start()
    {
        // Aseg�rate de que el texto est� desactivado al inicio
        if (textObject != null)
        {
            textObject.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto detectado tiene el Tag espec�fico
        if (other.CompareTag(targetTag))
        {
            if (textObject != null)
            {
                textObject.gameObject.SetActive(true); // Muestra el texto
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el objeto que sale tiene el Tag espec�fico
        if (other.CompareTag(targetTag))
        {
            if (textObject != null)
            {
                textObject.gameObject.SetActive(false); // Oculta el texto
            }
        }
    }
}

