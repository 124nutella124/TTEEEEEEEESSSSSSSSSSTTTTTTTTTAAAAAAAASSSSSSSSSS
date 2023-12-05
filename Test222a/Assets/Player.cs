using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of player movement

    void Update()
    {
        // Get input for player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the player based on input
        MovePlayer(movement);
    }

    void MovePlayer(Vector3 movement)
    {
        // Translate the player in the specified direction
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
