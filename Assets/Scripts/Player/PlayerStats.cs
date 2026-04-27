using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    private PlayerAnimator playerAnimator;

    void Start()
    {
        currentHealth = maxHealth;
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        playerAnimator.PlayHurt();
        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerAnimator.PlayDeath();
        Debug.Log("Player died!");
        FindAnyObjectByType<GameOverUI>().ShowGameOver();
        gameObject.SetActive(false);
    }
}