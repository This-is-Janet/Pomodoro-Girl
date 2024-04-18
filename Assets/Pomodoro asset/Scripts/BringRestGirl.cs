using UnityEngine;

public class ActivateObjects : MonoBehaviour
{
    // Reference to GameObject A
    public GameObject restGirl;

    // Reference to GameObject B
    public GameObject sitGirl;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure objectA and objectB references are set
        if (restGirl == null || sitGirl == null)
        {
            Debug.LogError("Object references not set in ActivateObjects script!");
        }

        ActivateObjectsAB();
    }

    // Method to activate objects A and deactivate object B
    public void ActivateObjectsAB()
    {
        if (restGirl != null)
        {
            restGirl.SetActive(true);
        }
        if (sitGirl != null)
        {
            sitGirl.SetActive(false);
        }
    }
}