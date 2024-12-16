using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController1 : MonoBehaviour
{
    public GameObject shield; // Arrastra aquí el objeto del escudo en el Inspector.
    public KeyCode activateKey = KeyCode.Space; // Tecla para activar/desactivar el escudo.
    public float shieldDuration = 5f; // Duración máxima del escudo (en segundos).
    private bool isShieldActive = false;
    private Coroutine shieldCoroutine; // Referencia a la corrutina del escudo.

    private void Update()
    {
        // Detectar si se presiona la tecla para alternar el escudo.
        if (Input.GetKeyDown(activateKey))
        {
            if (isShieldActive)
            {
                DeactivateShield(); // Si está activo, desactivar el escudo.
            }
            else
            {
                ActivateShield(); // Si está inactivo, activar el escudo.
            }
        }
    }

    private void ActivateShield()
    {
        isShieldActive = true;
        shield.SetActive(true); // Activar el escudo.
        shield.GetComponent<Collider>().enabled = true; // Activar el Collider del escudo.

        // Iniciar la corrutina de desactivación automática si tiene una duración definida.
        if (shieldCoroutine != null) StopCoroutine(shieldCoroutine); // Detener corrutina previa, si existe.
        shieldCoroutine = StartCoroutine(DeactivateShieldAfterTime());
    }

    private void DeactivateShield()
    {
        isShieldActive = false;
        shield.SetActive(false); // Desactivar el escudo.
        shield.GetComponent<Collider>().enabled = false; // Desactivar el Collider del escudo.

        // Detener la corrutina de desactivación automática si estaba corriendo.
        if (shieldCoroutine != null)
        {
            StopCoroutine(shieldCoroutine);
            shieldCoroutine = null;
        }
    }

    private IEnumerator DeactivateShieldAfterTime()
    {
        yield return new WaitForSeconds(shieldDuration); // Esperar el tiempo definido.
        DeactivateShield(); // Desactivar el escudo automáticamente.
    }

    // Método para bloquear balas (usando colisión con el escudo).
    private void OnTriggerEnter(Collider other)
    {
        if (isShieldActive && other.CompareTag("Bullet")) // Si el escudo está activo y choca con una bala.
        {
            Destroy(other.gameObject); // Destruir la bala enemiga.
        }
    }
}





