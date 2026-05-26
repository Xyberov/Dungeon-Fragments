using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public CoinModel Model { get; private set; }

    void Awake()
    {
        Model = new CoinModel();
        Model.Add(PlayerPrefs.GetInt("Coins", 0));
        Model.OnCountChanged += count => PlayerPrefs.SetInt("Coins", count);
    }

    public void AddCoins(int amount)
    {
        Model.Add(amount);
        Debug.Log("Монет: " + Model.Count);
    }
}