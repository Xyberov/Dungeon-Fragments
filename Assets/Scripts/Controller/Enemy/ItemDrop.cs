using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject arrowPrefab;

    [SerializeField] private bool canDropArrows = false;

    public void Drop()
    {
        float roll = Random.value;

        if (canDropArrows)
        {
            //скелет 50% монеты 40% стрелы 10% ничего
            if (roll < 0.5f)
                SpawnCoins(Random.Range(1, 3));
            else if (roll < 0.9f)
                SpawnArrows(Random.Range(2, 6));
        }
        else
        {
            //Зомби 100% монеты
            SpawnCoins(Random.Range(1, 4));
        }
    }

    void SpawnCoins(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 offset = Random.insideUnitCircle * 0.5f;
            Instantiate(coinPrefab, new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, -1f), Quaternion.identity);
        }
    }

    void SpawnArrows(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 offset = Random.insideUnitCircle * 0.5f;
            Instantiate(arrowPrefab, new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, -1f), Quaternion.identity);
        }
    }
}