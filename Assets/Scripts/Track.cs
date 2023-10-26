using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Transform follow;
    void Update()
    {
        transform.position = follow.position;
    }
}
