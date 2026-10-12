using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{        
    public float moveSpeed = 5f;    // How fast the pipes move to the left (in units per sec)
    public float deadZone = -45;    // x position where pipes are considered offscreen and get destroyed

    // Update is called once per frame
    void Update()
    {
        // move pipe left every frame at a constant speed
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // if the pipe moves past the deadZone, remove it from the scene
        if (transform.position.x < deadZone)
            Destroy(gameObject);
    }
}
