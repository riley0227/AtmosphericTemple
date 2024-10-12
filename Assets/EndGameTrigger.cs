using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class EndGameTrigger : MonoBehaviour
{
    public GameObject endGameScreen; // Reference to the end game UI screen
    public TMP_Text completionTimeText; // TextMeshPro text to display the completion time
    public TMP_Text highScoreText; // TextMeshPro text to display the high score
    public LevelManager levelManager; // Reference to the LevelManager script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the timer
            levelManager.StopTimer();

            // Show the end game screen
            endGameScreen.SetActive(true);

            // Display the time completed
            float finalTime = levelManager.GetElapsedTime();
            completionTimeText.text = "Time Completed: " + finalTime.ToString("F2") + "s";

            // Display the high score
            highScoreText.text = "High Score: " + PlayerPrefs.GetFloat(levelManager.levelName + "_HighScore", 0f).ToString("F2") + "s";

            // Optionally, pause the game
            Time.timeScale = 0f;
        }
    }
}
