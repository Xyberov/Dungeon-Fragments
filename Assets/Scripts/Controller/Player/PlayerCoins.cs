using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public CoinModel Model { get; private set; }

    void Awake()
    {
        Model = new CoinModel();
    }

    public void AddCoins(int amount)
    {
        Model.Add(amount);
        Debug.Log("Монет: " + Model.Count);
    }
}