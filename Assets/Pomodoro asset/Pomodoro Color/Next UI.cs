using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NextUI : MonoBehaviour
{
    public GameObject[] screens; // Assign your screens in the Inspector
    public float screenDuration = 4f; // Duration for each screen in seconds
    private int currentScreenIndex = 0;

    void Start()
    {
        StartCoroutine(ShowScreens());
    }

    IEnumerator ShowScreens()
    {
        while (currentScreenIndex < screens.Length)
        {
            // Activate the current screen
            screens[currentScreenIndex].SetActive(true);

            // Wait for the specified duration
            yield return new WaitForSeconds(screenDuration);

            // Deactivate the current screen
            screens[currentScreenIndex].SetActive(false);

            // Move to the next screen
            currentScreenIndex++;
        }

        // Optional: Do something after showing all screens
        Debug.Log("All screens shown");
    }
}