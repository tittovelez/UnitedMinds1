using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity_horizontal;
    public float sensitivity_vertical;
    public Camera cam;
    public float minAngles;
    public float maxAngles;

    private float horizontalAngle;
    private float verticalAngle;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * sensitivity_horizontal;
        horizontalAngle += horizontal;
        transform.localRotation = Quaternion.Euler(0, horizontalAngle, 0);

        float vertical = Input.GetAxis("Mouse Y") * sensitivity_vertical;
        verticalAngle += vertical;
        verticalAngle = Mathf.Clamp(verticalAngle, minAngles, maxAngles);
        cam.transform.localRotation = Quaternion.Euler(verticalAngle, 0, 0);
    }
}
