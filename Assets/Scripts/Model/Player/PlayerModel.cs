using System;

public class PlayerModel
{
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    public event Action<float> OnHealthChanged;
    public event Action OnDamaged;
    public event Action OnDied;

    public PlayerModel(float maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 0) CurrentHealth = 0;
        OnHealthChanged?.Invoke(CurrentHealth);
        OnDamaged?.Invoke();
        if (CurrentHealth <= 0)
            OnDied?.Invoke();
    }
}