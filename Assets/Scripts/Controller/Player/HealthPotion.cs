using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int startCount = 3;
    public float healAmount = 30f;
    public float cooldown = 3f;

    public HealthPotionModel Model { get; private set; }

    private PlayerStats playerStats;
    private float lastUseTime = -99f;

    [SerializeField] private AudioClip healSound;
    private AudioSource audioSource;

    void Awake()
    {
        Model = new HealthPotionModel(startCount, healAmount, cooldown);
    }

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TryHeal();
    }

    void TryHeal()
    {
        if (Time.time - lastUseTime < cooldown) return;
        if (!Model.TryUse()) return;

        playerStats.Model.Heal(healAmount);
        audioSource.PlayOneShot(healSound);
        lastUseTime = Time.time;
        Debug.Log("Хилка использована, осталось: " + Model.Count);
    }
}