using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] rotationController _rotationController;
    [SerializeField] MoveController _moveController;
    
    

    private void Update()
    {
        _rotationController.inputRotationX = Input.GetAxis("Mouse Y");
        _rotationController.inputRotationY = Input.GetAxis("Mouse X");

        _moveController.horizontalInput = Input.GetAxis("Horizontal");
        _moveController.verticalInput = Input.GetAxis("Vertical");
    }
}
