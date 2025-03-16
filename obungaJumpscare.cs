using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene transitions

// This script handles the jumpscare animation and death transition when the player is caught by Obunga.
public class obungaJumpscare : MonoBehaviour
{
    // Reference to Obunga's Animator component to trigger the jumpscare animation.
    public Animator obungaAnim;

    // Reference to the player GameObject so we can disable it during the jumpscare.
    public GameObject player;

    // Duration of the jumpscare before transitioning to the death scene.
    public float jumpscareTime;

    // Name of the scene to load after the jumpscare ends ("deathScreen").
    public string sceneName;

    // Detects when the player enters the trigger zone.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensures the trigger only activates for the player.
        {
            // Disables the player to prevent further movement or interactions.
            player.SetActive(false);

            // Triggers the jumpscare animation.
            obungaAnim.SetTrigger("jumpscare");

            // Starts a coroutine that waits for the jumpscare duration before loading the death screen.
            StartCoroutine(jumpscare());
        }
    }

    // Coroutine to handle the delay before transitioning to the death scene.
    IEnumerator jumpscare()
    {
        // Wait for the jumpscare animation to finish.
        yield return new WaitForSeconds(jumpscareTime);

        // Load the death scene.
        SceneManager.LoadScene(sceneName);
    }
}
