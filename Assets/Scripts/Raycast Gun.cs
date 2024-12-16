using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public LayerMask mask;
    public Camera playerCamera;
    public Transform laserOrigin;
    public float GunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;

    LineRenderer laserLine;
    float fireTimer;
    // Start is called before the first frame update

     void Awake()
    {
        laserLine = GetComponent<LineRenderer>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            fireTimer = 0;
            //laserLine.SetPosition(0, laserOrigin.position);
            RaycastHit hit;
            if(Physics.Raycast(laserOrigin.position, laserOrigin.forward, out hit, GunRange,mask))
            {
                //laserLine.SetPosition(1, hit.point);
                Destroy(hit.transform.gameObject);
            }
            else
            {
                //laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * GunRange));
            }
            StartCoroutine(ShootLaser());
        }
        
    }
    IEnumerator ShootLaser()
    {
        //laserLine.enabled = true;
        yield return new  WaitForSeconds(laserDuration) ;
        //laserLine.enabled = false;
    }
}
