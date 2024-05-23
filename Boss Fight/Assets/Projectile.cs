using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifetime = 2f;
    [SerializeField] int damageAmount = 1; 

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss"))
        {
            
            BossHealth bossHealth = other.GetComponent<BossHealth>();

            
            if (bossHealth != null)
            {
                bossHealth.TakeDamage(damageAmount);
            }

            
            Destroy(gameObject);
        }
    }
}




