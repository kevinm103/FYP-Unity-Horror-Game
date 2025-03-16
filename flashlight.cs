using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the flashlight functionality, allowing the player to turn it on and off.

public class flashlight : MonoBehaviour
{
    // The GameObject representing the flashlight's light source
    public GameObject light;
    
    // Boolean to track whether the flashlight is on or off
    public bool toggle;
    
    // Audio source for the flashlight toggle sound effect
    public AudioSource toggleSound;

    // Start is called before the first frame update
    void Start()
    {
        // Ensures the flashlight starts in the correct state
        if(toggle == false)
        {
            light.SetActive(false); // Flashlight is off 
        }
        if (toggle == true)
        {
            light.SetActive(true); // Flashlight is on 
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // Checks if the player presses the 'F' key to toggle the flashlight
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggle = !toggle; // Switch the toggle state (on/off)

            // Plays the flashlight toggle sound
            // toggleSound.Play();

            // Turns the light on or off based on the toggle state
            if(toggle == false)
            {
                light.SetActive(false);
            }
            if (toggle == true)
            {
                light.SetActive(true);
            }
        }
    }
}
