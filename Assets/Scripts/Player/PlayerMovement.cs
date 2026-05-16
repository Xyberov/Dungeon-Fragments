using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // движение
    public float speed = 5f;
    public float stopDistance = 0.15f;
    public LayerMask enemyLayer;

    private Rigidbody2D rb;
    private Camera cam;
    private PlayerCombat combat;

    private Vector2 moveTarget;
    private Transform enemyTarget;
    private bool hasTarget = false;
    private Vector2 movement;

    //рывок
    public float dashSpeed = 20f;
    public float dashDuration = 0.15f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private float dashTimer = 0f;
    private float cooldownTimer = 0f;
    private Vector2 dashDirection;

    // анимация
    private PlayerAnimator playerAnimator;

    //стамина
    private PlayerStamina stamina;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        combat = GetComponent<PlayerCombat>();
        playerAnimator = GetComponent<PlayerAnimator>();

        stamina = GetComponent<PlayerStamina>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }

        cooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f && !isDashing)
        {
            StartDash();
        }

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f) StopDash();
        }

        if (hasTarget)
        {
            PursueTarget();
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
            rb.MovePosition(rb.position + dashDirection * dashSpeed * Time.fixedDeltaTime);
        else
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void HandleClick()
    {
        Vector2 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hit = Physics2D.OverlapPoint(worldPos, enemyLayer);

        if (hit != null)
        {
            enemyTarget = hit.transform;
        }
        else
        {
            enemyTarget = null;
            moveTarget = worldPos;
        }

        hasTarget = true;
    }

    void PursueTarget()
    {
        Vector2 destination;

        if (enemyTarget != null)
        {
            if (!enemyTarget.gameObject.activeInHierarchy)
            {
                ClearTarget();
                return;
            }

            destination = enemyTarget.position;
            float dist = Vector2.Distance(transform.position, destination);

            if (dist <= combat.swordRange)
            {
                movement = Vector2.zero;
                combat.TrySwordAttack(enemyTarget);
                return;
            }
        }
        else
        {
            destination = moveTarget;
            float dist = Vector2.Distance(transform.position, destination);

            if (dist <= stopDistance)
            {
                ClearTarget();
                return;
            }
        }

        movement = (destination - (Vector2)transform.position).normalized;
        playerAnimator.SetWalking(true);
    }

    void ClearTarget()
    {
        hasTarget = false;
        enemyTarget = null;
        movement = Vector2.zero;
        playerAnimator.SetWalking(false);
    }

    void StartDash()
    {
        if (!stamina.TryUseStamina(stamina.dashCost)) return;

        isDashing = true;
        dashTimer = dashDuration;
        cooldownTimer = dashCooldown;

        ClearTarget();

        Vector2 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        dashDirection = (worldPos - (Vector2)transform.position).normalized;
    }

    void StopDash()
    {
        isDashing = false;
    }
}
