using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the interaction for picking up a flashlight in the game.

public class pickupFlashlight : MonoBehaviour
{
    // UI text that appears when the player can pick up the flashlight
    public GameObject inttext; 
    
    // The flashlight object that is on the table (before pickup)
    public GameObject flashlight_table; 
    
    // The flashlight object that the player holds (after pickup)
    public GameObject flashlight_hand; 
    
    // Audio source for the pickup sound effect
    public AudioSource pickup; 
    
    // Boolean to track whether the player is in range and can interact
    public bool interactable; 

    // Detects if the player is near and looking at the flashlight
    void OnTriggerStay(Collider other)
    {
        // Ensures only the player can interact (MainCamera used for first-person detection)
        if (other.CompareTag("MainCamera"))
        {
            // Shows the interaction prompt
            inttext.SetActive(true);
            
            // Enables interaction
            interactable = true;
        }
    }

    // Detects when the player moves out of range of the flashlight
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            // Hides the interaction prompt
            inttext.SetActive(false);
            
            // Disables interaction
            interactable = false;
        }
    }

    // Update runs every frame
    void Update()
    {
        // Checks if the player is in range and can interact
        if (interactable == true)
        {
            // Detects if the player presses the "E" key to pick up the flashlight
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Hides the interaction prompt
                inttext.SetActive(false);
                
                // Disables interaction to prevent re-triggering
                interactable = false;

                // Plays the pickup sound 
                // pickup.Play();

                // Enables the flashlight in the player's hand
                flashlight_hand.SetActive(true);
                
                // Disables the flashlight on the table to simulate it being picked up
                flashlight_table.SetActive(false);
            }
        }
    }
}
