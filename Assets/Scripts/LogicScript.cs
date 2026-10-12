using UnityEngine;
using UnityEngine.UI;               // needed for using ui text
using UnityEngine.SceneManagement;  // allows scene loading and restarting

public class LogicScript : MonoBehaviour
{
    public int playerScore;             // keeps track of the player's score
    public Text scoreText;              // reference to on-screen score display
    public GameObject gameOverScreen;   // reference to game-over screen display
    public AudioSource ding;            // reference to sound file for score increase
    public AudioSource endOfGame;        // reference to sound file for game over screen

    // function increases the score by a given amount
    [ContextMenu("Increase Score")] // lets you test this in unity editor menu
    public void addScore(int amount)
    {
        ding.Play();
        playerScore += amount;                      // add 1 to total score         
        scoreText.text = playerScore.ToString();    // update the text on ui screen
    }

    // function restarts the game scene and resumes time
    public void restartGame()
    {
        // resumes time for the scene since gameOver() stops it
        Time.timeScale = 1f;
        // reloads the active scene by its current name
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // function ends the current game and freezes time so the bird stops all movement 
    public void gameOver()
    {
        endOfGame.Play();               // end of game sound
        gameOverScreen.SetActive(true); // display the game over ui
        Time.timeScale = 0f;            // stops time so all movement ceases
    }
}
