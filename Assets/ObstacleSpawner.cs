using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Array to hold different obstacle prefabs (e.g., tree, rock, etc.)
    public GameObject[] obstacles;

    // The interval between spawning obstacles (in seconds)
    public float spawnInterval = 2f;

    // The maximum distance from the center where obstacles can spawn
    public float spawnRadius = 50f;

    void Start()
    {
        // Start spawning obstacles at regular intervals
        InvokeRepeating("SpawnObstacle", 0f, spawnInterval);
    }
    void SpawnObstacle()
{
    // Get a random position within the spawn radius
    Vector3 spawnPosition = new Vector3(
        Random.Range(-spawnRadius, spawnRadius),  // Random x-coordinate
        0f,                                      // We'll update the y-coordinate based on the terrain
        Random.Range(-spawnRadius, spawnRadius)   // Random z-coordinate
    );

    // Get the terrain's height at the spawn x and z coordinates
    Terrain terrain = Terrain.activeTerrain;  // Get the active terrain in the scene
    float y = terrain.SampleHeight(spawnPosition);  // Sample the terrain's height at that position
    spawnPosition.y = y;  // Set the y-coordinate of the spawn position to the terrain height

    // Choose a random obstacle from the obstacles array
    int randomIndex = Random.Range(0, obstacles.Length);

    // Get the selected obstacle prefab
    GameObject obstacle = obstacles[randomIndex];

    // Instantiate the selected obstacle at the random position (on the terrain)
    Instantiate(obstacle, spawnPosition, Quaternion.identity);  // No rotation
}
}
