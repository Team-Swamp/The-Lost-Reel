using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        var horizontal = Input.GetAxisRaw("Horizontal") * movementSpeed;
        var vertical = Input.GetAxisRaw("Vertical") * movementSpeed;

        var move = new Vector3(horizontal, rb.velocity.y, vertical);
        rb.velocity = move * movementSpeed * Time.deltaTime;
    }
}
