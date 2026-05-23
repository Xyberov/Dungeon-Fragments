using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float regenRate = 15f;
    public float regenDelay = 1f;
    public float dashCost = 25f;

    public StaminaModel Model { get; private set; }
    private float regenTimer = 0f;

    void Awake()
    {
        Model = new StaminaModel(maxStamina);
    }

    void Update()
    {
        regenTimer -= Time.deltaTime;
        if (regenTimer <= 0f && Model.CurrentStamina < Model.MaxStamina)
            Model.Regenerate(regenRate * Time.deltaTime);
    }

    public bool TryUseStamina(float amount)
    {
        bool success = Model.TryUseStamina(amount);
        if (success) regenTimer = regenDelay;
        return success;
    }

    public float GetStamina() => Model.CurrentStamina;
    public float GetMaxStamina() => Model.MaxStamina;
}