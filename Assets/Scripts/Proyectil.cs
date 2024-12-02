using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public GameObject bala;
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            GameObject bullet = Instantiate(bala) as GameObject;

            bullet.AddComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().mass = 3;
            bullet.GetComponent<Rigidbody>().AddForce(ray.direction * velocidad);
            bullet.AddComponent<BoxCollider>();
        }
    }
}
