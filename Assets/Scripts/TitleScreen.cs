using UnityEngine;
using UnityEngine.SceneManagement;  // provides access to Unity's scene management functionality
using UnityEngine.UI;               // provides access to UI components such as Image and Text

public class TitleScreen : MonoBehaviour
{
    public Image birdPreview;       // UI image displaying the selected bird
    public Text birdColorText;      // UI text displaying the selected bird's colour name
    public Sprite[] birdColors;     // array containing the four available bird sprites
    private int selectedBird;       // index of the currently selected bird

    // Colour names corresponding to the indices in the birdColors array
    private string[] colorNames =
    {
        "RED", "BLUE", "GREEN", "PURPLE"
    };

    // Called when the title screen starts
    void Start()
    {
        // Retrieve the previously selected bird, defaulting to red
        selectedBird = PlayerPrefs.GetInt("SelectedBird", 0);

        // Display the saved bird selection on the title screen
        UpdateBirdPreview();
    }

    // Called when the player clicks the PLAY button
    public void PlayGame()
    {
        // Reset the time scale in case the previous game was paused
        Time.timeScale = 1f;

        // Load the Main gameplay scene
        SceneManager.LoadScene("Main");
    }

    // Cycle forward through the bird colours, wrapping back to the first bird
    public void NextBird()
    {
        // Increase the index unless the last bird is already selected
        if (selectedBird < birdColors.Length - 1)
            selectedBird++;
        else
            selectedBird = 0;

        // Update the preview and save the new selection
        UpdateBirdPreview();
    }

    // Cycle backward through the bird colours, wrapping to the last bird
    public void PreviousBird()
    {
        // Decrease the index unless the first bird is already selected
        if (selectedBird > 0)
            selectedBird--;
        else
            selectedBird = birdColors.Length - 1;

        // Update the preview and save the new selection
        UpdateBirdPreview();
    }

    // Update the title screen UI and save the selected bird for future scenes
    private void UpdateBirdPreview()
    {
        // Display the bird sprite corresponding to the selected index
        birdPreview.sprite = birdColors[selectedBird];

        // Display the matching colour name using the same array index
        birdColorText.text = colorNames[selectedBird];

        // Store the selected bird index so BirdScript can retrieve it in the Main scene
        PlayerPrefs.SetInt("SelectedBird", selectedBird);

        // Write the PlayerPrefs changes to persistent storage
        PlayerPrefs.Save();
    }
}