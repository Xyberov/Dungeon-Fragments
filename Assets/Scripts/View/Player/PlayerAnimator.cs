using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        var stats = GetComponent<PlayerStats>();
        stats.Model.OnDamaged += PlayHurt;
        stats.Model.OnDied += PlayDeath;
    }

    void Update()
    {
        FlipTowardsCursor();
    }

    void FlipTowardsCursor()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteRenderer.flipX = mouseWorld.x < transform.position.x;
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void PlayAttack()
    {
        animator.SetTrigger("attack");
    }

    public void PlayAttackBow()
    {
        animator.SetTrigger("attackBow");
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