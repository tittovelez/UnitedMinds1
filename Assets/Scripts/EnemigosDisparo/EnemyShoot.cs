using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform firePoint;    // Punto de disparo
    public float fireRate = 2f;    // Tiempo entre disparos
    public float bulletSpeed = 10f; // Velocidad de la bala
    public AudioSource shootSound; // AudioSource para el sonido del disparo

    private float nextFireTime = 0f;
    private bool playerDetected = false; // Indica si el jugador está en rango

    void Update()
    {
        // Solo dispara si el jugador ha sido detectado
        if (playerDetected && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Instanciar la bala
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;

        // Reproducir el sonido del disparo
        if (shootSound != null)
        {
            shootSound.Play();
        }
        else
        {
            Debug.LogWarning("No se ha asignado un AudioSource para el sonido del disparo.");
        }
    }

    // Detectar al jugador cuando entra en el rango
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
        {
            playerDetected = true;
        }
    }

    // Dejar de detectar al jugador cuando sale del rango
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }
}


