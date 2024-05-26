using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpikeRotation : MonoBehaviour
{
    [SerializeField] float offsetAngle = -90f; // Adjust this angle if needed

    void Update()
    {
        // Get the velocity of the ice spike
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;

        // Calculate the angle of the velocity
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        // Apply the offset angle
        angle += offsetAngle;

        // Rotate the ice spike sprite
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}


