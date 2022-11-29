using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public Rigidbody rb;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float runningSpeed = 2f;
    
    public float horizontalInput;
    public float verticalInput;
    private void FixedUpdate()
    {
        rb.AddForce((transform.forward * verticalInput + transform.right * horizontalInput) * speed, ForceMode.Force);

        /*if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce((transform.forward * verticalInput + transform.right * horizontalInput) * runningSpeed, ForceMode.Force);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.AddForce((transform.forward * verticalInput + transform.right * horizontalInput) * speed, ForceMode.Force);
        }*/
    }
    
    
}
