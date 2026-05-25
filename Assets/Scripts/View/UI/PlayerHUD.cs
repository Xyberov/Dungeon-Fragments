using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [Header("HP")]
    [SerializeField] private Image hpIcon;
    [SerializeField] private Slider hpBar;

    [Header("Stamina")]
    [SerializeField] private Image staminaIcon;
    [SerializeField] private Slider staminaBar;

    [Header("Potions")]
    [SerializeField] private Image potionIcon;
    [SerializeField] private TextMeshProUGUI potionText;

    [Header("Arrows")]
    [SerializeField] private Image arrowIcon;
    [SerializeField] private TextMeshProUGUI arrowText;

    [Header("Coins")]
    [SerializeField] private Image coinIcon;
    [SerializeField] private TextMeshProUGUI coinText;

    private PlayerCombat playerCombat;

    void Start()
    {
        var stats = FindAnyObjectByType<PlayerStats>();
        var stamina = FindAnyObjectByType<PlayerStamina>();
        var potion = FindAnyObjectByType<HealthPotion>();
        var coins = FindAnyObjectByType<PlayerCoins>();
        playerCombat = FindAnyObjectByType<PlayerCombat>();

        //хп
        hpBar.maxValue = stats.Model.MaxHealth;
        hpBar.value = stats.Model.CurrentHealth;
        stats.Model.OnHealthChanged += val => hpBar.value = val;

        //стамина
        staminaBar.maxValue = stamina.Model.MaxStamina;
        staminaBar.value = stamina.Model.CurrentStamina;
        stamina.Model.OnStaminaChanged += val => staminaBar.value = val;

        //хилка
        potionText.text = potion.Model.Count.ToString();
        potion.Model.OnCountChanged += val => potionText.text = val.ToString();

        //монетки
        coinText.text = coins.Model.Count.ToString();
        coins.Model.OnCountChanged += val => coinText.text = val.ToString();
    }

    void Update()
    {
        arrowText.text = playerCombat.GetArrows().ToString();
    }
}