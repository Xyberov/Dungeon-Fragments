using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private Transform shadow;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        shadow = transform.Find("Shadow");

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
        bool lookLeft = mouseWorld.x < transform.position.x;
        spriteRenderer.flipX = lookLeft;

        if (shadow != null)
        {
            float offset = 0.12f;
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