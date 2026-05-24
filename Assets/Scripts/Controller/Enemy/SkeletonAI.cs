using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    public float chaseRange = 6f;
    public float attackRange = 4f;
    public float retreatRange = 2f;

    public float speed = 2f;
    public float shootCooldown = 2f;

    public GameObject enemyArrowPrefab;
    public Transform arrowSpawnPoint;

    private Transform player;
    private Rigidbody2D rb;
    private float lastShotTime;

    private EnemyAnimator enemyAnimator;
    enum State { Chase, Attack, Retreat }
    private State state = State.Chase;

    [SerializeField] private AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        enemyAnimator = GetComponent<EnemyAnimator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GetComponent<Knockback>()?.IsKnockedBack == true) return;
        if (player == null) return;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= retreatRange)
            state = State.Retreat;
        else if (dist <= attackRange)
            state = State.Attack;
        else if (dist <= chaseRange)
            state = State.Chase;
        else
            state = State.Chase;

        switch (state)
        {
            case State.Chase:
                MoveToward(player.position);
                break;

            case State.Attack:
                rb.linearVelocity = Vector2.zero;
                enemyAnimator.SetWalking(false);
                TryShoot();
                break;

            case State.Retreat:
                MoveAway(player.position);
                TryShoot();
                break;
        }
    }

    void MoveToward(Vector2 target)
    {
        Vector2 dir = (target - (Vector2)transform.position).normalized;
        rb.linearVelocity = dir * speed;
        enemyAnimator.SetWalking(true);
    }

    void MoveAway(Vector2 target)
    {
        Vector2 dir = ((Vector2)transform.position - target).normalized;
        rb.linearVelocity = dir * speed;
        enemyAnimator.SetWalking(true);
    }

    void TryShoot()
    {
        if (Time.time - lastShotTime < shootCooldown) return;
        if (enemyArrowPrefab == null || arrowSpawnPoint == null) return;
        audioSource.PlayOneShot(shootSound);

        Vector2 dir = (player.position - arrowSpawnPoint.position).normalized;
        GameObject arrow = Instantiate(enemyArrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
        arrow.GetComponent<EnemyArrow>().Init(dir);
        enemyAnimator.PlayAttack();
        lastShotTime = Time.time;
    }
}