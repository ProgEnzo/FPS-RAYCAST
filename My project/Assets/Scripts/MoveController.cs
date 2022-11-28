using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public Rigidbody rb;
    [SerializeField] private float speed = 1f;
    
    public float horizontalInput;
    public float verticalInput;
    private void Update()
    {
        rb.AddForce((transform.forward * verticalInput + transform.right * horizontalInput) * speed, ForceMode.Acceleration);
    }
}
