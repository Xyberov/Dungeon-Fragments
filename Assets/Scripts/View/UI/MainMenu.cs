using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject levelSelectPanel;
    [SerializeField] private TextMeshProUGUI resetMessage;

    void Start()
    {
        resetMessage.text = "";
    }

    public void OpenLevelSelect()
    {
        mainPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void Back()
    {
        levelSelectPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }

    public void ResetCoins()
    {
        PlayerPrefs.DeleteKey("Coins");
        StartCoroutine(ShowResetMessage());
    }

    private IEnumerator ShowResetMessage()
    {
        resetMessage.text = "Coins reset!";
        yield return new WaitForSeconds(2.5f);
        resetMessage.text = "";
    }

    public void Quit()
    {
        Application.Quit();
    }
}