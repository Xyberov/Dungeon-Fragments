using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    public bool HasSpawned { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (HasSpawned) return;
        if (!other.CompareTag("Player")) return;

        HasSpawned = true;
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject prefab = enemyPrefabs[i % enemyPrefabs.Length];
            Instantiate(prefab, spawnPoints[i].position, Quaternion.identity);
        }
    }
}