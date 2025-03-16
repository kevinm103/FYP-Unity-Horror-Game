using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script manages the interaction and toggling of a light switch in the game.

public class lightSwitch : MonoBehaviour
{
    // UI text to display interaction prompt
    public GameObject inttext; 
    
    // Light object that will be toggled on and off
    public GameObject light; 
    
    // Boolean to track if the light is on or off
    public bool toggle = true; 
    
    // Boolean to determine if the player is looking at the switch and can interact
    public bool interactable; 
    
    // Renderer component of the light bulb to change its material when toggled
    public Renderer lightBulb; 
    
    // Material for the light bulb when the light is off
    public Material offlight; 
    
    // Material for the light bulb when the light is on
    public Material onlight; 
    
    // Audio source for the light switch sound effect
    public AudioSource lightSwitchSound; 
    
    // Animator component for the light switch animation
    public Animator switchAnim; 

    // This function detects when the player is within range and looking at the light switch
    void OnTriggerStay(Collider other)
    {
        // Ensures the player is the one interacting (using MainCamera as reference)
        if (other.CompareTag("MainCamera"))
        {
            // Enables interaction text UI
            inttext.SetActive(true);
            
            // Sets the interactable flag to true
            interactable = true;
        }
    }

    // This function detects when the player moves out of range of the light switch
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            // Disables interaction text UI
            inttext.SetActive(false);
            
            // Sets the interactable flag to false
            interactable = false;
        }
    }

    // Update function runs every frame
    void Update()
    {
        // Checks if the player is in range and looking at the switch
        if (interactable == true)
        {
            // Detects if the player presses the "E" key to interact
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Toggles the boolean value (true to false, or false to true)
                toggle = !toggle;

                // Plays the light switch sound
                // lightSwitchSound.Play(); 

                // Resets and triggers the light switch animation
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");
            }
        }

        // Updates the light state and changes bulb material based on toggle value
        if (toggle == false) // If light is off
        {
            light.SetActive(false); // Disable the light object
            lightBulb.material = offlight; // Set the bulb material to "off" state
        }

        if (toggle == true) // If light is on
        {
            light.SetActive(true); // Enable the light object
            lightBulb.material = onlight; // Set the bulb material to "on" state
        }
    }
}
