using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;         // reference to prefab of the pipe pair to be spawned
    public float spawnRate = 3f;    // Time (in seconds) between pipe spawns
    private float timer = 0f;       // Counts time since last pipe was created
    public float heightOffset = 8;  // max vertical variation for pipe spawn

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();    // Spawn the first pipe immedaitely
    }

    // Update is called once per frame
    void Update()
    {
        // Add the time passed since the last frame to the timer
        if (timer < spawnRate)
            timer += Time.deltaTime;    //Time.dalteTime = seconds since last frame
        else
        {
            SpawnPipe();    // Create a new pipe
            timer = 0f;     // Reset the timer
        }
    }

    // Creates a new pipe at random y value
    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;    // lowest possible spawn height
        float highestPoint = transform.position.y + heightOffset;   // highest possible spawn height
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
