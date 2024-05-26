using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcespikeDamage : MonoBehaviour
{
    public int damageAmount = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Deal damage to the player
            other.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

           
        }
    }

}
