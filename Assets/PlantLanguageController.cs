using UnityEngine;
using TMPro;

public class PlantLanguageController : MonoBehaviour
{
    [Header("Text Objects")]
    public GameObject englishTextObject;
    public GameObject hindiTextObject;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip englishClip;
    public AudioClip hindiClip;

    // This function will be called by your Toggle
    public void SetLanguage(bool isHindi)
    {
        // 1. Toggle Text Visibility
        if (englishTextObject != null) englishTextObject.SetActive(!isHindi);
        if (hindiTextObject != null) hindiTextObject.SetActive(isHindi);

        // 2. Switch Audio Clip
        if (audioSource != null)
        {
            audioSource.clip = isHindi ? hindiClip : englishClip;
            
            // Optional: If audio is already playing, restart it in the new language
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                audioSource.Play();
            }
        }
    }
}