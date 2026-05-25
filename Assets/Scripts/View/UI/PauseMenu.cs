using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SetPause(!isPaused);
    }

    private void SetPause(bool state)
    {
        isPaused = state;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void Resume() => SetPause(false);
    public void MainMenu() { Time.timeScale = 1f; SceneManager.LoadScene("MainMenu"); }
}