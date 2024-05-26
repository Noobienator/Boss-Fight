using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isInvulnerable = false;
    private Animator animator;
    public Slider healthSlider; // Reference to the slider in the UI

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        UpdateHealthBar(); // Update the health bar when the game starts
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;

        currentHealth -= damage;
        UpdateHealthBar(); // Update the health bar when taking damage

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Move>().enabled = false;
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
