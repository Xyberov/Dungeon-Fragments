using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public PlayerModel Model { get; private set; }

    [SerializeField] private AudioClip damageSound;
    private AudioSource audioSource;

    void Awake()
    {
        Model = new PlayerModel(maxHealth);
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage, Vector2 hitFrom = default)
    {
        Model.TakeDamage(damage);
        GetComponent<HitPause>()?.Pause(0.1f);
        audioSource.PlayOneShot(damageSound, 0.3f);
        GetComponent<Knockback>()?.Apply(hitFrom);
    }
}