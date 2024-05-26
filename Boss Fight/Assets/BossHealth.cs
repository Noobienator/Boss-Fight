using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isInvulnerable = false;
    private Animator animator;
    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;

        UpdateHealthBar();

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
    }

    public void SetInvulnerable(bool invulnerable)
    {
        isInvulnerable = invulnerable;
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth; // Update the slider's value to match current health
    }
}
