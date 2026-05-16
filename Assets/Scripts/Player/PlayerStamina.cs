using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float regenRate = 15f;      // в секунду
    public float regenDelay = 1f;      // пауза перед восстановлением
    public float dashCost = 25f;

    private float currentStamina;
    private float regenTimer = 0f;

    void Start()
    {
        currentStamina = maxStamina;
    }

    void Update()
    {
        regenTimer -= Time.deltaTime;

        if (regenTimer <= 0f && currentStamina < maxStamina)
        {
            currentStamina += regenRate * Time.deltaTime;
            currentStamina = Mathf.Min(currentStamina, maxStamina);
        }
    }

    public bool TryUseStamina(float amount)
    {
        if (currentStamina < amount) return false;

        currentStamina -= amount;
        regenTimer = regenDelay;
        return true;
    }

    public float GetStamina() => currentStamina;
    public float GetMaxStamina() => maxStamina;
}