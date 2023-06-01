using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;             // The target object to follow
    [SerializeField] private float distance = 5.0f;        // The distance from the target
    [SerializeField] private float height = 3.0f;          // The height of the camera above the target
    [SerializeField] private float smoothSpeed = 10.0f;    // The smoothness of camera movement

    private Vector3 offset;              // The offset from the target position

    private void Start()
    {
        // Calculate the initial offset from the target position
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculate the desired position based on the target's position, distance, and height
        Vector3 desiredPosition = target.position + offset.normalized * distance + Vector3.up * height;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Make the camera look at the target
       
            transform.LookAt(target);
        
    }
}