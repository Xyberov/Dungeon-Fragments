using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        var player = FindAnyObjectByType<PlayerStats>();
        player.Model.OnDied += ShowGameOver;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}