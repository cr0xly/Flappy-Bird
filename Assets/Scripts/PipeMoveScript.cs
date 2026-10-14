using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;    // speed at which the pipes move left, in units per second
    public float deadZone = -45f;   // X position beyond which pipes are destroyed

    // Called once per frame to move pipes and check their position
    void Update()
    {
        // Move the pipe pair left at a frame-rate-independent speed
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // Destroy the pipe pair once it passes the left-side boundary
        if (transform.position.x < deadZone)
            Destroy(gameObject);
    }
}