using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationController : MonoBehaviour
{
    [SerializeField] private float limitX = 75;
    [SerializeField] private float rotationSpeed = 500;
    [SerializeField] public Transform head;

    private float rotationX;
    public Rigidbody rb;

    public float inputRotationX, inputRotationY;

    private void Update()
    {
        rotationX -= inputRotationX * rotationSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -limitX, limitX);
        head.localRotation = Quaternion.Euler(rotationX, 0, 0);
        
        transform.localRotation*= Quaternion.Euler(0, inputRotationY * rotationSpeed * Time.deltaTime, 0);
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 15);
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            head.localRotation = Quaternion.Euler(0, 0, 45);
        }
        if(Input.GetKey(KeyCode.E))
        {
            head.localRotation = Quaternion.Euler(0, 0, -45);
        }
    }
}
