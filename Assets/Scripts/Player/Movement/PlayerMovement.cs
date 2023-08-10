using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    
    private Vector3 _moveDirection;
    private Vector3 _velocity;
    private float _horizontal;
    private float _vertical;
    private bool _isGrounded;

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0) _velocity.y = 0f;
            
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _moveDirection = transform.right * _horizontal + transform.forward * _vertical;

        characterController.Move(_moveDirection * movementSpeed * Time.deltaTime);

        _velocity.y += gravity * Time.deltaTime;

        characterController.Move(_velocity * Time.deltaTime);
    }
}
