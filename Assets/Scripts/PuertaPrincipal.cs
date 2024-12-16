using UnityEngine;

public class DoorController1 : MonoBehaviour
{
    public float openAngle = 90f; // Ángulo de apertura
    public float openSpeed = 2f; // Velocidad de apertura
    public bool isOpen = false;  // Estado de la puerta

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        // Define la rotación inicial y final
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    void Update()
    {
        if (isOpen)
        {
            // Interpola la rotación para abrir la puerta
            transform.rotation = Quaternion.Lerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
        }
    }
}

