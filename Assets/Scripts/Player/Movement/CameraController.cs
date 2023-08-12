using UnityEngine;

public sealed class CameraController : MonoBehaviour
{
    [field: SerializeField]public float mouseSensitivity { get; set; } = 250.0f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private float xRotation;

    private float _mouseX;
    private float _mouseY;

    private void Start() => Cursor.lockState = CursorLockMode.Locked;

    private void Update()
    {
        SetMousePosition();
        RotateCameraAndPlayer();
    }
    
    private void SetMousePosition()
    {
        _mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }

    private void RotateCameraAndPlayer()
    {
        xRotation -= _mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f,0f);
        playerBody.Rotate(Vector3.up * _mouseX);
    }
}
