using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements like Text

// This script handles player interactions with objects that display dialogue when interacted with.

public class interact : MonoBehaviour
{
    // Boolean to check if the player is near and can interact with the object
    public bool interactable, toggle;

    // UI elements for interaction prompt and dialogue display
    public GameObject inttext, dialogue;

    // String to store the dialogue text
    public string dialogueString;

    // Text component to display the dialogue on screen
    public Text dialogueText;

    // Time in seconds before the dialogue disappears
    public float dialogueTime;

    // Detect when the player is within the interaction range
    void OnTriggerStay(Collider other)
    {
        // Checks if the player camera is looking at the object
        if (other.CompareTag("MainCamera"))
        {
            // Ensures interaction text is shown only if the object has not been interacted with before
            if(toggle == false)
            {
                inttext.SetActive(true); // Display interaction text
                interactable = true; // Enable interaction
            }
        }
    }

    // Detect when the player leaves the interaction range
    void OnTriggerExit(Collider other)
    {
        // If the player moves away, hide the interaction text and disable interaction
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }

    // Check for player input to interact with the object
    void Update()
    {
        // If the object is interactable and the player presses 'E'
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueText.text = dialogueString; // Update the dialogue text
                dialogue.SetActive(true); // Show the dialogue box
                inttext.SetActive(false); // Hide the interaction prompt
                StartCoroutine(disableDialogue()); // Start the timer to hide dialogue
                toggle = true; // Mark the object as interacted to prevent re-triggering
                interactable = false; // Disable interaction after triggering
            }
        }
    }

    // Coroutine to hide the dialogue after a set duration
    IEnumerator disableDialogue()
    {
        yield return new WaitForSeconds(dialogueTime); // Wait for the set dialogue time
        dialogue.SetActive(false); // Hide the dialogue box
    }
}
