using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public float distance = 10;
    public float speed = 4;
    public LayerMask mask;
    private Rigidbody obj;
    private float currentDistance;
    private Vector3 desiredPosition;
    private Vector3 lastPosition;
    private Vector3 velocity;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance, mask))
            {
                currentDistance = hit.distance;
                obj = hit.rigidbody;
            }
        }

        if (Input.GetButton("Fire1") && obj)
        {
            currentDistance += Input.mouseScrollDelta.y;
            currentDistance = Mathf.Clamp(currentDistance, 1, distance);
            desiredPosition = transform.position + transform.forward * currentDistance;
            obj.velocity = Vector3.zero;
            lastPosition = obj.transform.position;
            obj.transform.position = Vector3.Lerp(obj.transform.position, desiredPosition, Time.deltaTime * speed);
            velocity = (obj.transform.position - lastPosition) / Time.deltaTime;
        }
        if (Input.GetButtonUp("Fire1") && obj)
        {
            obj.velocity = velocity;
            obj = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position + transform.forward, transform.forward * (distance - 1f), Color.red);
        if (obj)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(desiredPosition, 0.1f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(obj.transform.position, 0.1f);
            Debug.DrawRay(transform.position + transform.forward, transform.forward * (currentDistance - 1f), Color.green);
        }
    }
}
