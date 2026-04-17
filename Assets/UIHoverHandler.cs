using UnityEngine;
using System.Collections;

public class UIHoverHandler : MonoBehaviour
{
    [Header("Settings")]
    public GameObject uiPanel;
    [Tooltip("How long the UI stays visible after you stop looking at the plant")]
    public float hideDelay = 1.5f; // Increase this number to increase seconds

    private Coroutine hideCoroutine;

    public void ShowUI()
    {
        // If a "Hide" timer is already running, stop it so the UI stays open
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        uiPanel.SetActive(true);
    }

    public void HideUIWithDelay()
    {
        // Start the timer to hide the UI
        hideCoroutine = StartCoroutine(DelayHide());
    }

    private IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(hideDelay);
        uiPanel.SetActive(false);
    }
}