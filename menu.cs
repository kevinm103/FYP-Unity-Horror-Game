using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene transitions

// This script manages the game's main menu, including loading the game scene and handling the cursor.

public class menu : MonoBehaviour
{
    // Loading screen UI, which is shown when transitioning to the game.
    public GameObject loadingscreen;

    // The name of the scene to be loaded when the player starts the game.
    public string sceneName;

    // This method is called when the script is first run.
    void Start()
    {
        // Ensure the cursor is visible when in the menu.
        Cursor.visible = true;

        // Unlocks the cursor so the player can move it freely.
        Cursor.lockState = CursorLockMode.None;
    }

    // This method is called when the player clicks the "Play Game" button.
    public void playGame()
    {
        // Activate the loading screen before transitioning to the game scene.
        loadingscreen.SetActive(true);

        // Load the specified scene.
        SceneManager.LoadScene(sceneName);
    }
}
