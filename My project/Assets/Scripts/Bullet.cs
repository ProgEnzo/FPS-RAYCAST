using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    public float speed;

    public void Start()
    {
        rb.AddForce(Vector3.forward * speed);
    }
}
