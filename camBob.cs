using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the camera bobbing animation when the player walks or sprints.

public class camBob : MonoBehaviour
{
    // Reference to the Animator component controlling camera animations
    public Animator cameraAnim;

    // Boolean to determine if the player is currently walking
    public bool walking;

    void Update()
    {
        // Check if the player is pressing movement keys (W, A, S, D)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walking = true; // Player is moving

            // Reset idle and sprint animations to ensure proper transition
            cameraAnim.ResetTrigger("idle");
            cameraAnim.ResetTrigger("sprint");

            // Trigger the walking animation
            cameraAnim.SetTrigger("walk");

            // Check if the player is sprinting (holding Left Shift while moving)
            if (walking == true)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    // Reset walk animation and transition to sprinting animation
                    cameraAnim.ResetTrigger("walk");
                    cameraAnim.ResetTrigger("idle");
                    cameraAnim.SetTrigger("sprint");
                }
            }
        }
        else
        {
            // If no movement keys are pressed, transition to idle animation
            cameraAnim.ResetTrigger("walk");
            cameraAnim.ResetTrigger("sprint");
            cameraAnim.SetTrigger("idle");

            walking = false; // Player is not moving
        }
    }
}
