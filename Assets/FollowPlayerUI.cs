using UnityEngine;

public class SmoothFollowUI : MonoBehaviour
{
    [Header("Targeting")]
    public Transform playerCamera;
    public float distance = 1.5f;
    public float heightOffset = -0.2f;

    [Header("Smoothing")]
    public float followSpeed = 5f;
    public float rotationSpeed = 5f;

    private bool isVisible = false;

    void Update()
    {
        if (!isVisible) return;

        // Calculate the ideal position in front of the player
        Vector3 targetPos = playerCamera.position + (playerCamera.forward * distance);
        targetPos.y += heightOffset;

        // Smoothly move the UI to that position
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);

        // Smoothly rotate the UI to face the player
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - playerCamera.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    public void ToggleUI(bool show)
    {
        isVisible = show;
        if (!show) gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }
}