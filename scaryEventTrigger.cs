using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is responsible for triggering a jump scare event when the player enters a specific area.

public class scaryEventTrigger : MonoBehaviour
{
    // Reference to the scare object (e.g., a jumpscare model, animation, or effect).
    public GameObject scare;

    // Reference to the audio source that plays the scare sound.
    public AudioSource scareSound;

    // Reference to the collider that acts as the trigger zone.
    public Collider collision;

    // This method is called when another collider enters the trigger zone.
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the "Player" tag.
        if (other.CompareTag("Player"))
        {
            // Activate the scare object (e.g., a sudden appearing monster or jumpscare effect).
            scare.SetActive(true);

            // Play the scare sound 
            // scareSound.Play();

            // Disable the trigger collider to prevent the event from being triggered multiple times.
            collision.enabled = false;
        }
    }
}
