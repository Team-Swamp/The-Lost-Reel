using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed;
    
    private Vector3 _moveDirection;
    private float _x;
    private float _z;

    private void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");

        _moveDirection = transform.right * _x + transform.forward * _z;

        characterController.Move(_moveDirection * movementSpeed * Time.deltaTime);
    }
}
