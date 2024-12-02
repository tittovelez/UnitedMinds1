using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public GameObject shield; // Arrastra tu objeto del escudo aquí en el Inspector
    public KeyCode activateKey = KeyCode.E; // Cambia la tecla si es necesario

    private bool isShieldActive = false;

    void Update()
    {
        // Detectar si se presiona la tecla
        if (Input.GetKeyDown(activateKey))
        {
            ToggleShield();
        }
    }

    void ToggleShield()
    {
        // Alternar el estado del escudo
        isShieldActive = !isShieldActive;
        shield.SetActive(isShieldActive);
    }
}

