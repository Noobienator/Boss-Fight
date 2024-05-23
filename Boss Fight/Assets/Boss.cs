using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFlipToFacePlayer : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Find the player GameObject by tag and get its Transform component
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the SpriteRenderer component of the boss
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if player is to the left or right of the boss
        if (player.position.x < transform.position.x)
        {
            // Player is to the left, so flip the sprite to face left
            spriteRenderer.flipX = false;
        }
        else
        {
            // Player is to the right, so flip the sprite to face right
            spriteRenderer.flipX = true;
        }
    }
}
