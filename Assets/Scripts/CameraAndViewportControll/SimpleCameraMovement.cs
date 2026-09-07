using UnityEngine;

public class SimpleCameraMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        // Get input for X and Z movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement based on input and speed
        Vector3 localMovement = new Vector3(moveX, 0, 0) * moveSpeed * Time.deltaTime;
        Vector3 globalMovement = new Vector3(0, 0, moveZ) * moveSpeed * Time.deltaTime;

        // Update the camera's position
        // We're modifying the local X component and the global Z component
        transform.Translate(localMovement, Space.Self);
        transform.Translate(globalMovement, Space.Self);
    }
}
