using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum DropType { Arrow, Coin }
    [SerializeField] private DropType dropType;
    [SerializeField] private int amount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (dropType == DropType.Arrow)
            other.GetComponent<PlayerCombat>()?.AddArrows(amount);

        Destroy(gameObject);
    }
}