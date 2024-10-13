using TMPro; // Add this line at the top of your script
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public GameObject endGameScreen; // Reference to the end game UI screen
    public TMP_Text highScoreText; // Reference to the high score text (TextMeshPro)
    public TMP_Text completionTimeText; // Reference to the completion time text (TextMeshPro)

    private float elapsedTime;
    private float highScore;

    private void Start()
    {
        endGameScreen.SetActive(false); // Make sure the end game screen is hidden at the start
        elapsedTime = 0f;
        highScore = PlayerPrefs.GetFloat("HighScore", float.MaxValue); // Load high score

        UpdateHighScoreText();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public void DisplayEndScreen()
    {
        Debug.Log("End Game Screen Activated!");

        // Show the end game screen
        endGameScreen.SetActive(true);

        // Display the completion time
        completionTimeText.text = "Completion Time: " + elapsedTime.ToString("F2") + "s";

        // Check if this is a new high score
        if (elapsedTime < highScore)
        {
            highScore = elapsedTime;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save(); // Save the new high score

            highScoreText.text = "New High Score: " + highScore.ToString("F2") + "s";
        }
        else
        {
            highScoreText.text = "High Score: " + highScore.ToString("F2") + "s";
        }

        // Pause the game
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Reset the time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    private void UpdateHighScoreText()
    {
        if (highScore == float.MaxValue)
        {
            highScoreText.text = "High Score: N/A";
        }
        else
        {
            highScoreText.text = "High Score: " + highScore.ToString("F2") + "s";
        }
    }
}
