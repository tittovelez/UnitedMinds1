using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody rb;
    public GroundDetector ground;
    public int airJumps;
    private int currentJumps;
    public float jumpForce;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (ground.grounded)
            {
                currentJumps = airJumps;
                rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
            }
            else if(currentJumps > 0)
            {
                currentJumps--;
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
        }
    }
}
