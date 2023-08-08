using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed;
    
    private Vector3 _moveDirection;
    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _moveDirection = transform.right * _horizontal + transform.forward * _vertical;

        characterController.Move(_moveDirection * movementSpeed * Time.deltaTime);
    }
}
