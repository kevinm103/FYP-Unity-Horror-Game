using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the player's ability to pick up a key when interacting with it.

public class pickupKey : MonoBehaviour
{
    // GameObject references for UI interaction text and the key itself
    public GameObject inttext, key;

    // Audio source for playing a pickup sound when the key is collected
    public AudioSource pickup;

    // Boolean to check if the player is in range to pick up the key
    public bool interactable;

    // Detects if the player is near the key and displays interaction text
    void OnTriggerStay(Collider other)
    {
        // Checks if the object colliding is the player's camera
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true); // Show interaction text
            interactable = true; // Enable interaction
        }
    }

    // Detects when the player moves away from the key and hides the interaction text
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false); // Hide interaction text
            interactable = false; // Disable interaction
        }
    }

    // Handles player input to pick up the key
    void Update()
    {
        // If the key is interactable and the player presses 'E'
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false); // Hide interaction text
                interactable = false; // Prevent further interaction
                
                // Plays the pickup sound 
                //pickup.Play();

                key.SetActive(false); // Hide the key (simulating pickup)
            }
        }
    }
}
