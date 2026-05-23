using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        var stats = GetComponent<PlayerStats>();
        stats.Model.OnDamaged += PlayHurt;
        stats.Model.OnDied += PlayDeath;
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