using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;

    private bool alreadyWon;
    private bool enemiesEverSpawned;

    private void Update()
    {
        if (alreadyWon) return;

        var enemies = FindObjectsByType<EnemyStats>(FindObjectsInactive.Exclude);
        var spawners = FindObjectsByType<EnemySpawner>(FindObjectsInactive.Exclude);

        if (enemies.Length > 0)
            enemiesEverSpawned = true;

        if (!enemiesEverSpawned) return;

        foreach (var s in spawners)
            if (!s.HasSpawned) return;

        foreach (var e in enemies)
            if (!e.IsDead) return;

        alreadyWon = true;
        StartCoroutine(ShowWin());
    }

    private IEnumerator ShowWin()
    {
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}