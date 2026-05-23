using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    private Transform shadow;

    private SpriteRenderer spriteRenderer;
    private Transform player;

    [SerializeField] private float shadowOffset = 0.12f;

    void Start()
    {
        animator = GetComponent<Animator>();
        shadow = transform.Find("Shadow");

        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        var stats = GetComponent<EnemyStats>();
        stats.Model.OnDamaged += PlayHurt;
        stats.Model.OnDied += PlayDeath;
    }

    void Update()
    {
        FlipTowardsPlayer();
    }

    void FlipTowardsPlayer()
    {
        if (player == null) return;
        bool lookLeft = player.position.x < transform.position.x;
        spriteRenderer.flipX = lookLeft;

        if (shadow != null)
        {
            float offset = shadowOffset;
            shadow.localPosition = new Vector3(lookLeft ? -offset : offset, shadow.localPosition.y, 0);
        }
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void PlayAttack()
    {
        animator.SetTrigger("attack");
    }

    public void PlayHurt()
    {
        animator.SetTrigger("hurt");
    }

    public void PlayDeath()
    {
        animator.SetTrigger("death");
    }
}

