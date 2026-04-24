using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 8f;
    public float damage = 15f;
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
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyStats>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}