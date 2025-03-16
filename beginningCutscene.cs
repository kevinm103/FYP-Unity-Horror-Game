using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the introductory cutscene at the start of the game.
// It disables the player object initially and enables it after the cutscene duration.

public class beginningCutscene : MonoBehaviour
{
    // Reference to the cutscene camera that is active during the cutscene
    public GameObject cutsceneCam;

    // Reference to the player object, which will be activated after the cutscene
    public GameObject player;

    // Duration of the cutscene in seconds
    public float cutsceneTime;

    // Start is called before the first frame update
    void Start()
    {
        // Begin the cutscene coroutine when the scene starts
        StartCoroutine(cutscene());
    }

    // Coroutine that waits for the duration of the cutscene and then enables the player
    IEnumerator cutscene()
    {
        // Waits for the specified cutscene time before continuing
        yield return new WaitForSeconds(cutsceneTime);

        // Activates the player object, allowing movement
        player.SetActive(true);

        // Disables the cutscene camera to transition to gameplay
        cutsceneCam.SetActive(false);
    }
}
