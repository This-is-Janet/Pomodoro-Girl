using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;

    // Reference to the GameObject representing "Time Up"
    public GameObject activeScreen;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();

        // Ensure animator reference is set
        if (animator == null)
        {
            Debug.LogError("Animator component not found in CharacterAnimatorController script!");
        }

        // Ensure timeUpGameObject reference is set
        if (activeScreen == null)
        {
            Debug.LogError("Time Up GameObject reference not set in CharacterAnimatorController script!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "Time Up" GameObject is active
        if (activeScreen.activeSelf)
        {
            // Trigger the "TimeUp" animation
            animator.SetTrigger("TimeUp");
        }
    }
}