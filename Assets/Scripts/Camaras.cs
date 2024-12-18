using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraSwitcher : MonoBehaviour
{
    public Camera camera1; // C�mara para el personaje 1
    public Camera camera2; // C�mara para el personaje 2

    public PlayerMovement12 character1Movement; // Script de movimiento del personaje 1
    public PersonMovement2 character2Movement; // Script de movimiento del personaje 2

    private Camera activeCamera; // C�mara actualmente activa

    private void Start()
    {
        // Configurar la c�mara y el personaje activos al inicio
        activeCamera = camera1;
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);

        // Solo el primer personaje puede moverse al inicio
        character1Movement.isActive = true;
        character2Movement.isActive = false;
    }

    private void Update()
    {
        // Cambiar de c�mara al presionar "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        if (activeCamera == camera1)
        {
            // Cambiar a la c�mara y el personaje 2
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
            activeCamera = camera2;

            // Solo el personaje 2 puede moverse
            character1Movement.isActive = false;
            character2Movement.isActive = true;
        }
        else
        {
            // Cambiar a la c�mara y el personaje 1
            camera2.gameObject.SetActive(false);
            camera1.gameObject.SetActive(true);
            activeCamera = camera1;

            // Solo el personaje 1 puede moverse
            character1Movement.isActive = true;
            character2Movement.isActive = false;
        }
    }
}
