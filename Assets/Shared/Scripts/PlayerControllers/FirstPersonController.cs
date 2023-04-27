using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 offset;
    private Vector3 moveDirection;

    void Update()
    {
        // Get input axis values for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate move direction based on input
        moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        // Rotate player based on mouse input
        float rotationInput = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(new Vector3(0.0f, rotationInput, 0.0f));
    }

    void FixedUpdate()
    {
        // Move player in FixedUpdate to ensure smooth physics-based movement
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(moveDirection.x, rigidbody.velocity.y, moveDirection.z);
    }
}

