using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

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
        var horizontal = Input.GetAxis("Horizontal") * movementSpeed;
        var vertical = Input.GetAxis("Vertical") * movementSpeed;
        
        _characterController.Move((Vector3.right * horizontal + Vector3.forward * vertical) * Time.deltaTime);
    }
}
