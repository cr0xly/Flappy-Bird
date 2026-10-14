using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    public LogicScript logic;   // reference to LogicScript for updating the player's score

    // Called when the scoring trigger is initialized
    void Start()
    {
        // Find the GameObject tagged "Logic" and retrieve its LogicScript component
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
    }

    // Called when another 2D collider enters the scoring trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only award points when the colliding object belongs to physics layer 3
        if (collision.gameObject.layer == 3)
        {
            // Award one point when the bird passes through the pipes
            logic.addScore(1);
        }
    }
}