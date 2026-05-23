using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer spriteRenderer;
    private Transform player;

    void Start()
    {
        animator = GetComponent<Animator>();

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
        spriteRenderer.flipX = player.position.x < transform.position.x;
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

