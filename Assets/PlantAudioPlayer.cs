using UnityEngine;
using UnityEngine.UI;

public class PlantAudioPlayer : MonoBehaviour
{
    public AudioSource plantAudio;
    public Image buttonImage; // Ensure this is linked to the Image component

    [Header("Icon Settings")]
    public Sprite whiteIdleIcon;
    public Sprite greenActiveIcon;

    private void Awake()
    {
        // This ensures the button is visible and white the moment the UI spawns
        if (buttonImage != null)
        {
            buttonImage.sprite = whiteIdleIcon;
            buttonImage.color = Color.white;
            buttonImage.gameObject.SetActive(true);
        }
    }

    public void TogglePlantSound()
    {
        if (plantAudio.isPlaying) StopPlantSound();
        else PlayPlantSound();
    }

    public void PlayPlantSound()
    {
        plantAudio.Play();
        if (buttonImage != null)
        {
            buttonImage.sprite = greenActiveIcon;
        }
    }

    public void StopPlantSound()
    {
        plantAudio.Stop();
        if (buttonImage != null)
        {
            buttonImage.sprite = whiteIdleIcon;
        }
    }
}