using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;

    private CharacterController _characterController;


    private void Start()
    {
        _characterController = gameObject.AddComponent<CharacterController>();
    }

    private void Update()
    {
        MovementPlayer();
    }

    public void MovementPlayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero) gameObject.transform.forward = move;
    }
}
