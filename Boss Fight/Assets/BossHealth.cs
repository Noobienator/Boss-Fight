using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private bool isInvulnerable = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;  

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject.Destroy(gameObject);
    }

    public void SetInvulnerable(bool invulnerable)
    {
        isInvulnerable = invulnerable;
    }
}
