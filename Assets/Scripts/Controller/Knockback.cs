using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float force = 5f;
    public float duration = 0.15f;

    public bool IsKnockedBack { get; private set; }
    private Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    public void Apply(Vector2 fromPosition)
    {
        StopAllCoroutines();
        StartCoroutine(DoKnockback(fromPosition));
    }

    private IEnumerator DoKnockback(Vector2 fromPosition)
    {
        IsKnockedBack = true;
        Vector2 dir = ((Vector2)transform.position - fromPosition).normalized;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(dir * force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(duration);
        rb.linearVelocity = Vector2.zero;
        IsKnockedBack = false;
    }
}