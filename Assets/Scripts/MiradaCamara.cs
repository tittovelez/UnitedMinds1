using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MiradaCamara : MonoBehaviour
{
    public float Velocidad = 100;
    float RotacionX = 0;
    public Transform Jugador;
    public Transform Camara;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * 100 * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * 100 * Time.deltaTime;

        RotacionX -= MouseY;
        RotacionX = Mathf.Clamp (RotacionX, -90f, -90f);

        transform.localRotation = Quaternion.Euler(RotacionX, -90f, 0f);
        transform.localRotation = Quaternion.Euler(RotacionX, -90f, 0f);
        Jugador.Rotate(Vector3.up * MouseX);
    }
}
