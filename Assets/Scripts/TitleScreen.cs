using UnityEngine;
using UnityEngine.SceneManagement; // allows scene loading and restarting

public class TitleScreen : MonoBehaviour
{
    public void PlayGame()
    {
        // make sure the game is running
        Time.timeScale = 1f;

        // load the Main scene
        SceneManager.LoadScene("Main");
    }
}
