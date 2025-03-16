using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles the activation of a generator trigger that disables certain blocks when the player enters the trigger zone.
public class GeneratorTrigger : MonoBehaviour
{
    // References to the GameObjects that represent the blocks which will be disabled when triggered.
    public GameObject block1, block2, block3;

    // Reference to the Collider component of the trigger area to disable it after activation.
    public Collider collision;

    // Boolean to check if blocks should be disabled when triggered.
    public bool blocks;

    // When collider enters the trigger zone.
    void OnTriggerEnter(Collider other)
    {
        // Checks if the object entering the trigger has the "Player" tag.
        if (other.CompareTag("Player"))
        {
            // If 'blocks' is true, disable the specified blocks.
            if (blocks == true)
            {
                block1.SetActive(false);
                block2.SetActive(false);
                block3.SetActive(false);
            }

            // Disable the collider to prevent multiple activations.
            collision.enabled = false;
        }
    }
}
