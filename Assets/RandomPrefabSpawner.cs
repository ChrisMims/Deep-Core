using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    public List<GameObject> prefabsToSpawn;
    public int gridWidth = 8;
    public int gridHeight = 40;
    public int numberOfObjectsToSpawn = 10;

    private List<Vector2> spawnPoints = new List<Vector2>();

    void Start()
    {
        GenerateSpawnPoints();
        SpawnPrefabs();
    }

    void GenerateSpawnPoints()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                spawnPoints.Add(new Vector2(x, y));
            }
        }
    }

    void SpawnPrefabs()
    {
        List<GameObject> spawnedPrefabs = new List<GameObject>();

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            int randomIndex = Random.Range(0, prefabsToSpawn.Count);
            GameObject prefabToSpawn = prefabsToSpawn[randomIndex];

            int attempts = 0;
            while (attempts < 100) // Limit the number of attempts to prevent infinite loop
            {
                int spawnPointIndex = Random.Range(0, spawnPoints.Count);
                Vector2 spawnPosition = spawnPoints[spawnPointIndex];

                bool overlaps = CheckOverlap(spawnPosition, prefabToSpawn, spawnedPrefabs);
                if (!overlaps)
                {
                    GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity, transform);
                    spawnedPrefabs.Add(spawnedObject);
                    spawnPoints.RemoveAt(spawnPointIndex);
                    break;
                }
                attempts++;
            }
        }
    }

    bool CheckOverlap(Vector2 position, GameObject prefab, List<GameObject> spawnedPrefabs)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, prefab.GetComponent<SpriteRenderer>().bounds.size, 0f);
        foreach (Collider2D collider in colliders)
        {
            if (spawnedPrefabs.Contains(collider.gameObject))
            {
                return true;
            }
        }
        return false;
    }
}
