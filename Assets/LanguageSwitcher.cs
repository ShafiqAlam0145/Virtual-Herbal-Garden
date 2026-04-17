using UnityEngine;
using TMPro;
using UnityEngine.UI; // Required for Image component

public class LanguageSwitcher : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject englishObject;
    public GameObject hindiObject;

    [Header("UI Button Text")]
    public TextMeshProUGUI buttonLabel;

    [Header("Audio Settings")]
    public AudioSource plantAudioSource;
    public AudioClip englishClip;
    public AudioClip hindiClip;

    [Header("Icon Settings")]
    public Image audioButtonImage; // Drag the AudioToggleButton's Image here
    public Sprite whiteIdleIcon;   // Your white speaker icon
    public Sprite greenActiveIcon; // Your green speaker icon

    private bool isEnglish = true;

    public void SwapLanguage()
    {
        isEnglish = !isEnglish;

        // 1. Switch Text Panels
        englishObject.SetActive(isEnglish);
        hindiObject.SetActive(!isEnglish);

        // 2. Switch EN/HI Label
        buttonLabel.text = isEnglish ? "EN" : "HI";

        // 3. Switch the clip but keep playing if it was already playing
        bool wasPlaying = plantAudioSource.isPlaying;
        plantAudioSource.clip = isEnglish ? englishClip : hindiClip;
        
        if (wasPlaying) plantAudioSource.Play();
    }

    public void ToggleAudio()
    {
        if (plantAudioSource.isPlaying)
        {
            plantAudioSource.Stop();
            audioButtonImage.sprite = whiteIdleIcon;
        }
        else
        {
            plantAudioSource.Play();
            audioButtonImage.sprite = greenActiveIcon;
        }
    }

    // Reset icon if audio ends naturally
    void Update()
    {
        if (!plantAudioSource.isPlaying && audioButtonImage.sprite == greenActiveIcon)
        {
            audioButtonImage.sprite = whiteIdleIcon;
        }
    }
}