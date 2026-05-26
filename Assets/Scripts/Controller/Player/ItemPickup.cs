using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum DropType { Arrow, Coin }
    [SerializeField] private DropType dropType;
    [SerializeField] private int amount = 1;

    [SerializeField] private AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (dropType == DropType.Arrow)
            other.GetComponent<PlayerCombat>()?.AddArrows(amount);

        if (dropType == DropType.Coin)
        {
            other.GetComponent<PlayerCoins>()?.AddCoins(amount);
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }

        Destroy(gameObject);
    }
}