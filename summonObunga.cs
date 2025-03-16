using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is responsible for summoning the AI enemy (Obunga) when the player enters a specific trigger zone.

public class summonObunga : MonoBehaviour
{
    // Reference to the enemy AI GameObject (Obunga)
    public GameObject obunga;

    // Block that will be removed/disabled when the enemy spawns
    public GameObject block1;

    // The collider used for triggering the event
    public Collider collision;

    // Boolean to determine whether the blocking objects should be removed
    public bool blocks;

    // This method detects when a player enters the trigger area
    void OnTriggerEnter(Collider other)
    {
        // Ensures that only the player can trigger the event
        if (other.CompareTag("Player"))
        {
            // Activates the AI enemy
            obunga.SetActive(true);

            // If the 'blocks' boolean is set to true, remove the block
            if(blocks == true)
            {
                block1.SetActive(false);
            }

            // Disables the collider to prevent the trigger from being activated again
            collision.enabled = false;
        }
    }
}
