using UnityEngine;

public class BillboardUI : MonoBehaviour
{
    public Transform playerCamera;
    public bool lockYAxis = true; // Set to true to prevent the UI from tilting up/down

    void LateUpdate()
    {
        if (playerCamera == null) return;

        // Determine the direction from the UI to the Camera
        Vector3 targetDirection = transform.position - playerCamera.position;

        if (lockYAxis)
        {
            targetDirection.y = 0; // Keeps the UI vertical (doesn't tilt)
        }

        // Apply the rotation
        if (targetDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }
}