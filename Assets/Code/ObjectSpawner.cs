using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float firstSpawnDelay;
    public float respawnTime;
    private float nextSpawnTime;
    private GameObject spawnedObject;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set the time for our first spawn
        nextSpawnTime = Time.time + firstSpawnDelay;       
    }

    // Update is called once per frame
    void Update()
    {
        // Check for spawn
        CheckForSpawn();
    }

    public void CheckForSpawn()
    {
        // If it is there is nothing spawns
        if (spawnedObject == null)
        {
            // And it is time to spawn
            if (Time.time > nextSpawnTime)
            {
                // Spawn it and set the next time
                spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + respawnTime;
            }
        }
        else
        {
            // Otherwise, the object still exists, so postpone the spawn
            nextSpawnTime = Time.time + respawnTime;
        }
    }
}
