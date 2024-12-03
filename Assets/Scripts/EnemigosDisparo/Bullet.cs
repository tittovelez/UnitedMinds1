using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Daño que inflige la bala

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth1 playerHealth = collision.gameObject.GetComponent<PlayerHealth1>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
        // Destruir la bala al colisionar
        Destroy(gameObject);
    }
}