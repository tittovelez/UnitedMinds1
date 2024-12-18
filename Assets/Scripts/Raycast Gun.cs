using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public LayerMask mask; // Capa para filtrar los objetos que puede golpear
    public Camera playerCamera;
    public Transform laserOrigin; // Punto desde donde se dispara el rayo
    public float GunRange = 50f;
    public float fireRate = 0.2f; // Cadencia de disparo
    public float laserDuration = 0.05f;
    public int damagePerHit = 5; // Daño progresivo por cada disparo

    LineRenderer laserLine;
    float fireTimer;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && fireTimer >= fireRate) // Solo dispara si el tiempo lo permite
        {
            fireTimer = 0; // Reinicia el temporizador de disparo
            RaycastHit hit;

            // Dispara un rayo hacia adelante
            if (Physics.Raycast(laserOrigin.position, laserOrigin.forward, out hit, GunRange, mask))
            {
                // Comprueba si el objeto golpeado tiene el script VidaEnemigo
                VidaEnemigo enemigo = hit.transform.GetComponent<VidaEnemigo>();
                if (enemigo != null)
                {
                    enemigo.RecibirDaño(damagePerHit); // Aplica daño al enemigo
                }
            }

            StartCoroutine(ShootLaser());
        }
    }

    IEnumerator ShootLaser()
    {
        // Visualización temporal del láser (si activas LineRenderer)
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}

