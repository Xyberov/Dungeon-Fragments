using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50f;
    public float damage = 10f;
    public float attackCooldown = 1f;

    private bool isDead = false;
    public bool IsDead => isDead;

    public EnemyModel Model { get; private set; }
    private float lastAttackTime;

    [SerializeField] private AudioClip deathSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Model = new EnemyModel(maxHealth);
        Model.OnDied += () => {
            if (isDead) return;
            isDead = true;
            audioSource.PlayOneShot(deathSound);
            GetComponent<ItemDrop>()?.Drop();
            Destroy(gameObject, 0.4f);
        };
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (Time.time - lastAttackTime < attackCooldown) return;

        collision.gameObject.GetComponent<PlayerStats>()?.TakeDamage(damage, transform.position);

        lastAttackTime = Time.time;
    }

    public void TakeDamage(float damage, Vector2 hitFrom = default)
    {
        Model.TakeDamage(damage);
        GetComponent<Knockback>()?.Apply(hitFrom);
        GetComponent<HitPause>()?.Pause(0.1f);
    }
}