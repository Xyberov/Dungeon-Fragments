using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public PlayerModel Model { get; private set; }

    void Awake()
    {
        Model = new PlayerModel(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        Model.TakeDamage(damage);
    }
}