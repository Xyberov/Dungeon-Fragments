using System;

public class StaminaModel
{
    public float MaxStamina { get; private set; }
    public float CurrentStamina { get; private set; }

    public event Action<float> OnStaminaChanged;

    public StaminaModel(float maxStamina)
    {
        MaxStamina = maxStamina;
        CurrentStamina = maxStamina;
    }

    public bool TryUseStamina(float amount)
    {
        if (CurrentStamina < amount) return false;
        CurrentStamina -= amount;
        OnStaminaChanged?.Invoke(CurrentStamina);
        return true;
    }

    public void Regenerate(float amount)
    {
        CurrentStamina = CurrentStamina + amount > MaxStamina ? MaxStamina : CurrentStamina + amount;
        OnStaminaChanged?.Invoke(CurrentStamina);
    }
}