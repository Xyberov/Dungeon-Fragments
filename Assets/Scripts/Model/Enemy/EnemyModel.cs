using System;

public class EnemyModel
{
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    public event Action OnDamaged;
    public event Action OnDied;

    public EnemyModel(float maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 0) CurrentHealth = 0;
        OnDamaged?.Invoke();
        if (CurrentHealth <= 0)
            OnDied?.Invoke();
    }
}