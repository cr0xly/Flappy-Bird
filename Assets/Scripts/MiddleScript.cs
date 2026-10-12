using UnityEngine;

public class MiddleScript : MonoBehaviour
{
    public LogicScript logic;   // reference to LogicScript that tracks score
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // find the object tagged "Logic" and get its LogicScript component
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
    }

    // adds to player's score when the bird collides
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // trigger only if object is on layer 3
        if (collision.gameObject.layer == 3)
            logic.addScore(1);   // increment the score by 1
    }
}
