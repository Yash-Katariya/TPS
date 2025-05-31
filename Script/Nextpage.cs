using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Nextpage : MonoBehaviour
{
    private MousePosition m_MousePosition;
    public float totalTime = 60f;
    private float remainingTime;

    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    public bool gameCompleted = false;

    void Start()
    {
        remainingTime = totalTime;
        gameOverPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        Time.timeScale = 1f; // In case you return from a paused state
    }
    void Update()
    {
        if (gameCompleted) return;

        remainingTime -= Time.deltaTime;
        remainingTime = Mathf.Max(0f, remainingTime);

        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 0f && !gameCompleted)
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameCompleted = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TriggerGameWin()
    {
        if (!gameCompleted)
        {
            gameCompleted = true;
            StartCoroutine(ShowWinPanelAfterDelay(1.5f));
        }
    }

    private IEnumerator ShowWinPanelAfterDelay(float delay)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("WIN TRIGGERED - Waiting " + delay + " sec");
        yield return new WaitForSeconds(delay);
        gameWinPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
