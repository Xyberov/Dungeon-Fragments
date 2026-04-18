using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float damage = 10f;
    public float attackCooldown = 1f;

    private float lastAttackTime;
    private PlayerStats player;

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
}