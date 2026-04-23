using UnityEngine;
public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50f;
    public float currentHealth;
    public float damage = 10f;
    public float attackCooldown = 1f;

    private float lastAttackTime;
    private PlayerStats player;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                player = collision.gameObject.GetComponent<PlayerStats>();
                player.TakeDamage(damage);
                lastAttackTime = Time.time;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}