using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TReespwaner : MonoBehaviour
{
    public GameObject treePrefab; // The tree prefab to be spawned
    public int numberOfTrees = 10; // Number of trees to spawn
    public float spawnRadius = 10f; 

    void Start()
    {
        SpawnTrees();
    }

    void SpawnTrees()
    {
        Terrain terrain = Terrain.activeTerrain;

        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 randomPosition = GetRandomPositionOnTerrain(terrain);

            // Instantiate the tree at the random position
            GameObject treeInstance = Instantiate(treePrefab, randomPosition, Quaternion.identity);

            // Ensure trees don't overlap
            AvoidTreeOverlap(treeInstance);
        }
    }

    Vector3 GetRandomPositionOnTerrain(Terrain terrain)
    {
        float randomX = Random.Range(0f, terrain.terrainData.size.x);
        float randomZ = Random.Range(0f, terrain.terrainData.size.z);
        float y = terrain.SampleHeight(new Vector3(randomX, 0f, randomZ)) + terrain.transform.position.y;

        return new Vector3(randomX, y, randomZ);
    }

    void AvoidTreeOverlap(GameObject tree)
    {
        Collider treeCollider = tree.GetComponent<Collider>();

        // Check for overlap with existing trees
        Collider[] colliders = Physics.OverlapSphere(tree.transform.position, spawnRadius);

        foreach (var collider in colliders)
        {
            if (collider != treeCollider && collider.CompareTag("Tree"))
            {
                // If there's an overlap, reposition the tree and check again
                Vector3 newPosition = GetRandomPositionOnTerrain(Terrain.activeTerrain);
                tree.transform.position = newPosition;

                // Recursive call to ensure the new position is also free of overlap
                AvoidTreeOverlap(tree);
                return;
            }
        }
    }
}
