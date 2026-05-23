using System;

public class HealthPotionModel
{
    public int Count { get; private set; }
    public float Cooldown { get; private set; }
    public float HealAmount { get; private set; }

    public event Action<int> OnCountChanged;

    public HealthPotionModel(int count, float healAmount, float cooldown)
    {
        Count = count;
        HealAmount = healAmount;
        Cooldown = cooldown;
    }

    public bool TryUse()
    {
        if (Count <= 0) return false;
        Count--;
        OnCountChanged?.Invoke(Count);
        return true;
    }
}