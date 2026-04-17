using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Call this from your "Start" button
    public void StartGame()
    {
        // Replace "MainScene" with the exact name of your game scene
        SceneManager.LoadScene("Main VR Scene");
    }

    // Call this from your "Quit" button
    public void QuitGame()
    {
        Application.Quit();
    }
}