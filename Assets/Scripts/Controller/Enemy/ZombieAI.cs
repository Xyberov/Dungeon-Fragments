using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 5f;
    public float loseRange = 8f;

    private EnemyAnimator enemyAnimator;

    private Rigidbody2D rb;
    private Transform player;
    private bool isAggro = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    void FixedUpdate()
    {
        if (GetComponent<Knockback>()?.IsKnockedBack == true) return;
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

        if (!isAggro && dist <= detectionRange)
            isAggro = true;

        if (isAggro && dist > loseRange)
            isAggro = false;

        if (isAggro)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            enemyAnimator.SetWalking(true);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            enemyAnimator.SetWalking(false);
        }
    }
}