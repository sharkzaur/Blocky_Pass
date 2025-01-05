using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallPrefab;       // Prefab of the wall to spawn
    public Transform spawnPoint;       // Position where walls will spawn
    public float spawnInterval = 2f;   // Time interval between spawns
    public float wallSpeed = 5f;       // Speed at which walls move forward

    private void Start()
    {
        // Start spawning walls at regular intervals
        InvokeRepeating(nameof(SpawnWall), 0f, spawnInterval);
    }

    private void SpawnWall()
    {
        // Instantiate the wall at the spawn point
        GameObject newWall = Instantiate(wallPrefab, spawnPoint.position, spawnPoint.rotation);

        // Attach a WallMover script to make it move forward
        WallMover wallMover = newWall.AddComponent<WallMover>();
        wallMover.speed = wallSpeed;
    }
}

