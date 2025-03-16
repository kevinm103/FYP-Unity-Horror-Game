using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Required for AI pathfinding

// This script controls the AI behavior for Obunga using NavMeshAgent
public class obunga : MonoBehaviour
{
    // Reference to the AI's NavMeshAgent component, which handles pathfinding
    public NavMeshAgent ai;

    // Reference to the player's Transform, used to track their position
    public Transform player;

    // The target destination for the AI
    Vector3 dest;

    void Update()
    {
        // Set the AI's destination to the player's current position
        dest = player.position;
        ai.destination = dest;
    }
}
