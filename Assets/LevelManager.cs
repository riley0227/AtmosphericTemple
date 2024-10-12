using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Text timerText; // UI text to display the timer
    public Text highScoreText; // UI text to display the high score
    private float elapsedTime;
    private bool isRunning;
    private float highScore;

    public string levelName; // Name of the current level

    void Start()
    {
        elapsedTime = 0f;
        isRunning = true;

        // Load the high score for this level
        LoadHighScore();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = "Time: " + elapsedTime.ToString("F2") + "s";
        }
    }

    public void StopTimer()
    {
        isRunning = false;

        // Check if the current time is a new high score
        if (elapsedTime < highScore || highScore == 0f)
        {
            highScore = elapsedTime;
            SaveHighScore();
            highScoreText.text = "New High Score: " + highScore.ToString("F2") + "s";
        }
        else
        {
            highScoreText.text = "High Score: " + highScore.ToString("F2") + "s";
        }
    }

    private void LoadHighScore()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetFloat(levelName + "_HighScore", 0f);
        highScoreText.text = "High Score: " + (highScore == 0f ? "N/A" : highScore.ToString("F2") + "s");
    }

    private void SaveHighScore()
    {
        // Save the high score to PlayerPrefs
        PlayerPrefs.SetFloat(levelName + "_HighScore", highScore);
        PlayerPrefs.Save();
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Reset time scale in case it was paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
