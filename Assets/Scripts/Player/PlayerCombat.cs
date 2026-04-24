using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Меч")]
    public float swordDamage = 25f;
    public float swordRange = 1.2f;
    public float swordCooldown = 0.5f;
    public LayerMask enemyLayer;

    [Header("Лук")]
    public GameObject arrowPrefab;
    public float bowCooldown = 1f;
    public Transform arrowSpawnPoint;

    private float lastSwordTime;
    private float lastBowTime;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Левая кнопка мыши меч
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastSwordTime >= swordCooldown)
            {
                SwordAttack();
                lastSwordTime = Time.time;
            }
        }

        // Правая кнопка мыши лук
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time - lastBowTime >= bowCooldown)
            {
                BowAttack();
                lastBowTime = Time.time;
            }
        }
    }

    void SwordAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, swordRange, enemyLayer);

        foreach (Collider2D hit in hits)
        {
            hit.GetComponent<EnemyStats>()?.TakeDamage(swordDamage);
            Debug.Log("Sword hit: " + hit.name);
        }
    }

    void BowAttack()
    {
        if (arrowPrefab == null || arrowSpawnPoint == null) return;

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)arrowSpawnPoint.position).normalized;

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
        arrow.GetComponent<Arrow>().Init(direction);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, swordRange);
    }
}