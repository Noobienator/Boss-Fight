using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float fixedY; // The y-coordinate you want to lock the camera at

    void Start()
    {
        // Initialize the fixedY value to the camera's current y position if not set
        if (fixedY == 0)
        {
            fixedY = transform.position.y;
        }
    }

    void LateUpdate()
    {
        // Follow the player's x position while keeping the y position fixed
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, fixedY, transform.position.z);
        }
    }
}
