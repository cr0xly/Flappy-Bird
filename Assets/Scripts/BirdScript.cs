using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;           // reference to the bird's Rigidbody2D component
    public float flapStrength;                  // upward velocity applied when the bird flaps
    public LogicScript logic;                   // reference to LogicScript for handling game over
    public bool birdIsAlive = true;             // tracks whether the bird is still alive
    public AudioSource flap;                    // sound played when the bird flaps
    public float outOfBounds = 13.5f;           // maximum positive or negative Y position before game over
    public Animator wingsAnimator;              // controls the bird's wing-flapping animations

    private SpriteRenderer birdSpriteRenderer;  // displays the bird's body sprite
    public Sprite[] birdColors;                 // body sprites for each available bird colour
    private int selectedBird;                   // index used to select the body, wings and animation
    private SpriteRenderer wingsSpriteRenderer; // displays the bird's wing sprite
    public Sprite[] wingColors;                 // resting wing sprites matching each bird colour

    // Animator state names corresponding to the indices in the sprite arrays
    private string[] wingAnimations =
    {
        "WingFlapRed", "WingFlapBlue", "WingFlapGreen", "WingFlapPurple"
    };

    // Called when the gameplay scene starts
    void Start()
    {
        // Disable the Animator so the wings remain stationary until the first flap
        wingsAnimator.enabled = false;

        // Find the GameObject tagged "Logic" and retrieve its LogicScript component
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // Retrieve the SpriteRenderer components for the bird's body and wings
        birdSpriteRenderer = GetComponent<SpriteRenderer>();
        wingsSpriteRenderer = wingsAnimator.GetComponent<SpriteRenderer>();

        // Retrieve the selected bird colour from PlayerPrefs, defaulting to red
        selectedBird = PlayerPrefs.GetInt("SelectedBird", 0);

        // Apply the selected body sprite and matching resting wing sprite
        birdSpriteRenderer.sprite = birdColors[selectedBird];
        wingsSpriteRenderer.sprite = wingColors[selectedBird];
    }

    // Called once per frame to check for player input and out-of-bounds movement
    void Update()
    {
        // Allow the bird to flap when Space is pressed, provided it is still alive
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            // Play the flap sound
            flap.Play();

            // Set the bird's upward velocity to make it flap
            myRigidBody2D.linearVelocity = Vector2.up * flapStrength;

            // Enable the Animator and restart the animation matching the selected bird
            wingsAnimator.enabled = true;
            wingsAnimator.Play(wingAnimations[selectedBird], 0, 0f);
        }

        // End the game if the living bird moves beyond the upper or lower Y boundary
        if (birdIsAlive && (transform.position.y > outOfBounds || transform.position.y < -outOfBounds))
        {
            // Prevent further flapping and repeated out-of-bounds deaths
            birdIsAlive = false;

            // Trigger the game-over sequence
            logic.gameOver();
        }
    }

    // Called when the bird collides with another non-trigger 2D collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Only trigger game over if the bird is still alive
        if (birdIsAlive)
        {
            birdIsAlive = false;
            logic.gameOver();
        }
    }
}