using System.Collections;
using UnityEngine;

public class FallingBlockController : MonoBehaviour
{
    public GameObject[] bloques; // Array de bloques que van a caer
    public Transform spawnPoint; // Punto de reaparici�n de los bloques (opcional)
    public float tiempoEntreCaidas = 2f; // Tiempo entre cada ca�da de bloque

    private bool jugadorEnZona = false;

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si el jugador entra en la zona
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = true;
            StartCoroutine(HacerCaerBloques());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detiene la ca�da cuando el jugador sale de la zona (opcional)
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = false;
            StopAllCoroutines();
        }
    }

    IEnumerator HacerCaerBloques()
    {
        while (jugadorEnZona)
        {
            foreach (GameObject bloque in bloques)
            {
                // Activar f�sica para que el bloque caiga
                Rigidbody rb = bloque.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false; // Permite que la f�sica act�e
                }

                yield return new WaitForSeconds(tiempoEntreCaidas);

                // Si quieres reiniciar los bloques, reaparici�n opcional
                if (spawnPoint != null)
                {
                    ReiniciarBloque(bloque);
                }
            }
        }
    }

    void ReiniciarBloque(GameObject bloque)
    {
        bloque.transform.position = spawnPoint.position;
        bloque.GetComponent<Rigidbody>().isKinematic = true;
    }
}

