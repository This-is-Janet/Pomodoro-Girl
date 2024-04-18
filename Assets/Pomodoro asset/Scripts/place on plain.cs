using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class placeonplain : MonoBehaviour
{
    public ARRaycastManager raycastManager; // Assign in inspector
    public GameObject audioParentPrefab; // Assign your prefab in inspector
    private bool isPrefabPlaced = false; // Flag to check if the prefab has been placed

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (!isPrefabPlaced)
            {
                PlacePrefab(touch.position);
            }

            CheckForSphere(touch.position);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (!isPrefabPlaced)
            {
                PlacePrefab(Input.mousePosition);
            }

            CheckForSphere(Input.mousePosition);
        }
    }

    private void PlacePrefab(Vector2 screenPosition)
    {
        // Raycast against planes.
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenPosition, hits, TrackableType.Planes);

        // Check if we hit an AR plane and the prefab has not been placed yet.
        if (hits.Count > 0 && !isPrefabPlaced)
        {
            Pose hitPose = hits[0].pose;

            // Instantiate the prefab at the hit position and rotation.
            Instantiate(audioParentPrefab, hitPose.position, hitPose.rotation);
            isPrefabPlaced = true; // Set flag to true so prefab is only placed once.
        }
    }

    private void CheckForSphere(Vector2 screenPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        // Check if the ray hits a GameObject with the tag "Sphere"
        if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("sphere"))
        {
            AudioSource audioSource = hit.collider.gameObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                // If audio is playing, pause it. Otherwise, play it.
                if (audioSource.isPlaying)
                {
                    audioSource.Pause();
                }
                else
                {
                    audioSource.Play();
                }
            }
        }
    }
}
