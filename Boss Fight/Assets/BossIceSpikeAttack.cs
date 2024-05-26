using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIceSpikeAttack : MonoBehaviour
{
    public float minTime = 5f; // Minimum time before the attack
    public float maxTime = 10f; // Maximum time before the attack
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackTimer());
    }

    IEnumerator AttackTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime)); // Wait for a random duration
            animator.SetTrigger("IceAttack"); // Trigger the ice attack animation
            yield return new WaitForSeconds(0.1f); // Wait for a short duration
            animator.ResetTrigger("IceAttack"); // Reset the trigger to allow for future attacks
        }
    }
}

