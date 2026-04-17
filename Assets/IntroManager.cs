using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour
{
    public CanvasGroup introCanvasGroup;
    public float fadeDuration = 1.5f;

    // This function will be called when the button is clicked
    public void StartGardenExperience()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float currentTime = 0;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            introCanvasGroup.alpha = Mathf.Lerp(1, 0, currentTime / fadeDuration);
            yield return null;
        }

        introCanvasGroup.alpha = 0;
        introCanvasGroup.blocksRaycasts = false;
        gameObject.SetActive(false); // Disables the canvas completely
    }
}