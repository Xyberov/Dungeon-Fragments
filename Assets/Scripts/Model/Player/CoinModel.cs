public class CoinModel
{
    public int Count { get; private set; }
    public event System.Action<int> OnCountChanged;

    public void Add(int amount)
    {
        Count += amount;
        OnCountChanged?.Invoke(Count);
    }
}