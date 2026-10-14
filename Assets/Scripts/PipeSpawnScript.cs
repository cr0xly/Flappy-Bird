using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;         // reference to the pipe pair prefab to instantiate
    public float spawnRate = 3f;    // time in seconds between pipe spawns
    private float timer = 0f;       // tracks elapsed time between pipe spawns
    public float heightOffset = 8;  // maximum vertical offset from the spawner's Y position

    // Called when the pipe spawner starts
    void Start()
    {
        // Spawn the first pipe immediately
        SpawnPipe();
    }

    // Called once per frame to control the pipe spawning interval
    void Update()
    {
        // Accumulate elapsed time until the next pipe should spawn
        if (timer < spawnRate)
        {
            // Time.deltaTime represents the time in seconds since the previous frame
            timer += Time.deltaTime;
        }
        else
        {
            // Spawn another pipe once the interval has been reached
            SpawnPipe();

            // Reset the timer for the next spawn
            timer = 0f;
        }
    }

    // Instantiate a pipe pair at a randomly selected vertical position
    void SpawnPipe()
    {
        // Calculate the minimum and maximum possible spawn heights
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Create a pipe pair at the spawner's X position and a random Y position
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}