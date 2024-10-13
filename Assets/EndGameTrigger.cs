using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public LevelManager levelManager; // Reference to the LevelManager script

    public void TriggerEndGame() // New public method
    {
        Debug.Log("Player reached the temple!");

        // Trigger the end game screen
        levelManager.DisplayEndScreen();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Use the new public method to trigger the end game logic
            TriggerEndGame();
        }
    }
}
