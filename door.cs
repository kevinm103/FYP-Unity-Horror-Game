using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles door interactions, including opening, closing, and locking mechanisms.

public class door : MonoBehaviour
{
    // UI elements: interaction text and locked message
    public GameObject intText, lockedText;

    // Key object to check if the player has collected it
    public GameObject key;

    // Boolean variables to determine if the player can interact with the door
    public bool interactable, toggle;

    // Animator component for handling door animations
    public Animator doorAnim;

    // Detects when the player is near the door
    void OnTriggerStay(Collider other)
    {
        // Checks if the object entering the trigger is the player's camera (ensuring correct interaction)
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true); // Shows interaction text
            interactable = true;     // Allows interaction with the door
        }
    }

    // Detects when the player leaves the door's interaction range
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false); // Hides interaction text
            interactable = false;     // Disables interaction
        }
    }

    void Update()
    {
        // If the player is within interaction range and presses "E"
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Check if the door requires a key and if the key has been collected
                if (key.active == false) // If the key is not active (collected), allow the door to open
                {
                    toggle = !toggle; // Toggles the door state (open/close)

                    if (toggle == true)
                    {
                        doorAnim.ResetTrigger("close");
                        doorAnim.SetTrigger("open"); // Triggers door opening animation
                    }
                    if (toggle == false)
                    {
                        doorAnim.ResetTrigger("open");
                        doorAnim.SetTrigger("close"); // Triggers door closing animation
                    }

                    intText.SetActive(false); // Hides interaction text after using the door
                    interactable = false;     // Prevents immediate reactivation
                }
                else // If the key is still active (not collected), display the locked message
                {
                    lockedText.SetActive(true);
                    StopCoroutine("disableText"); // Stop any previous coroutine to avoid conflicts
                    StartCoroutine("disableText"); // Start coroutine to disable text after delay
                }
            }
        }
    }

    // Coroutine to hide the "Locked" text after a delay
    IEnumerator disableText()
    {
        yield return new WaitForSeconds(2.0f);
        lockedText.SetActive(false);
    }
}
