using UnityEngine;
using UnityEngine.SceneManagement;  // provides access to Unity's scene management functionality
using UnityEngine.UI;               // provides access to UI components such as Text

public class LogicScript : MonoBehaviour
{
    public int playerScore;             // tracks the player's current score
    public int highScore;               // stores the highest score retrieved from PlayerPrefs
    public Text scoreText;              // reference to the on-screen score display
    public Text highScoreText;          // reference to the on-screen high score display
    public GameObject gameOverScreen;   // reference to the game-over UI
    public AudioSource ding;            // sound played when the player earns points
    public AudioSource endOfGame;       // sound played when the game ends

    // Called when the gameplay scene starts
    void Start()
    {
        // Retrieve the saved high score, defaulting to zero if none exists
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Display the saved high score on the UI
        highScoreText.text = "Best: " + highScore.ToString();
    }

    // Increase the player's score by the specified amount
    public void addScore(int amount)
    {
        // Play the scoring sound
        ding.Play();

        // Add the specified amount to the player's score
        playerScore += amount;

        // Update the score displayed on the UI
        scoreText.text = "Score: " + playerScore.ToString();
    }

    // Restart the current gameplay scene
    public void restartGame()
    {
        // Resume time because gameOver() pauses the game
        Time.timeScale = 1f;

        // Reload the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // End the game, update the high score and display the game-over screen
    public void gameOver()
    {
        // Prevent game over from executing multiple times
        if (gameOverScreen.activeSelf)
            return;

        // Save a new high score if the player beats their previous record
        if (playerScore > highScore)
        {
            highScore = playerScore;

            // Update the high score displayed on the UI
            highScoreText.text = "Best: " + highScore.ToString();

            // Store the new high score so it persists between game sessions
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        // Play the game-over sound and display the game-over UI
        endOfGame.Play();
        gameOverScreen.SetActive(true);

        // Pause the game by stopping scaled time
        Time.timeScale = 0f;
    }
}