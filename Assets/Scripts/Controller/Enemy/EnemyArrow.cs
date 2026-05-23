using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public float speed = 6f;
    public float damage = 10f;
    public float lifetime = 3f;

    private Vector2 direction;
    private Rigidbody2D rb;

    public void Init(Vector2 dir)
    {
        direction = dir;
        rb = GetComponent<Rigidbody2D>();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>()?.TakeDamage(damage, transform.position);
            Destroy(gameObject);
        }
    }
}