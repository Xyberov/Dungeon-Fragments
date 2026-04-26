using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float swordDamage = 25f;
    public float swordRange = 1.2f;
    public float swordCooldown = 0.5f;
    public LayerMask enemyLayer;

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
        //лук
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time - lastBowTime >= bowCooldown)
            {
                BowAttack();
                lastBowTime = Time.time;
            }
        }
    }

    public void TrySwordAttack(Transform target)
    {
        if (Time.time - lastSwordTime >= swordCooldown)
        {
            SwordAttack(target);
            lastSwordTime = Time.time;
        }
    }

    void SwordAttack(Transform target)
    {
        target.GetComponent<EnemyStats>()?.TakeDamage(swordDamage);
        Debug.Log("Sword hit: " + target.name);
    }

    void BowAttack()
    {
        if (arrowPrefab == null || arrowSpawnPoint == null) return;

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)arrowSpawnPoint.position).normalized;

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
        arrow.GetComponent<Arrow>().Init(direction);
    }
}