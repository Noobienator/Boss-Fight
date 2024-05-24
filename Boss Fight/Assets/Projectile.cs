using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifetime = 2f;
    [SerializeField] int damageAmount = 1;
    [SerializeField] float impactEffectLifetime = 0.5f; // Duration for the impact effect
    public GameObject impactEffect;

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

            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(impact, impactEffectLifetime); // Destroy impact effect after a delay

            Destroy(gameObject);
        }
    }
}
