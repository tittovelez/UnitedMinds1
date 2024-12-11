using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController1 : MonoBehaviour
{
    public GameObject shield; // Arrastra aquí el objeto del escudo en el Inspector.
    public KeyCode activateKey = KeyCode.Space; // Tecla para activar/desactivar el escudo.
    public float shieldDuration = 5f; // Duración del escudo (en segundos).
    private bool isShieldActive = false;

    private void Update()
    {
        // Detectar si se presiona la tecla para activar el escudo.
        if (Input.GetKeyDown(activateKey) && !isShieldActive)
        {
            ActivateShield();
        }
    }

    private void ActivateShield()
    {
        isShieldActive = true;
        shield.SetActive(true); // Activar el escudo.
        StartCoroutine(DeactivateShieldAfterTime());
    }

    private System.Collections.IEnumerator DeactivateShieldAfterTime()
    {
        yield return new WaitForSeconds(shieldDuration); // Esperar el tiempo definido.
        shield.SetActive(false); // Desactivar el escudo.
        isShieldActive = false;
    }
}

