using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class BirdScript : MonoBehaviour
{    
    public Rigidbody2D myRigidBody2D;   // controls bird physics and movement
    public float flapStrength;          // how strong each flap pushed the bird upward
    public LogicScript logic;           // reference to the LogicScript for scoring and game over
    public bool birdIsAlive = true;     // tracks if the bird is alive or not
    public AudioSource flap;            // reference to flap sound for space-bar
    public float outOfBounds = 13.5f;   // set Y boundary to end game when player reaches

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // fetches the Logic Script via Tag matching rather than direct relation
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame (60+ times per second)
    void Update()
    {
        // Check if the space key was just pressed down
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            // play flap sound
            flap.Play();
            // bird flap vertical movement
            myRigidBody2D.linearVelocity = Vector2.up * flapStrength;
        }

        // Check if bird is out of bounds
        if (transform.position.y > outOfBounds || transform.position.y < -outOfBounds)
        {
            birdIsAlive = false;    // trigger
            logic.gameOver();       // ends game and pauses time
        }
    }

    // function to end the game and pause time when the bird is hit or goes OOB
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // trigger the game over screen adn stop the bird from moving
        birdIsAlive = false;
        logic.gameOver();        
    }    
}
