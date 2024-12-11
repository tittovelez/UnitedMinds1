using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayosLaser : MonoBehaviour
{
    public GameObject Laser; // Objeto visual del láser
    public float laserRange = 100f; // Alcance del láser
    public LayerMask enemyLayer; // Capa para los enemigos

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopShooting();
        }
    }

    void Shoot()
    {
        Laser.SetActive(true);

        // Realizar un Raycast para detectar enemigos
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserRange, enemyLayer))
        {
            // Verificar si el objeto tiene el tag "Enemy"
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject); // Destruir al enemigo
            }
        }
    }

    void StopShooting()
    {
        Laser.SetActive(false);
    }
}