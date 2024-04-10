using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridWidth;
    public int gridHeight;
    public GameObject[,] gridArray;

    void Start()
    {
        gridArray = new GameObject[gridWidth, gridHeight];
        PopulateBoard();
    }

    void PopulateBoard()
    {

    }

    public void SpawnBrick(GameObject brickPrefab, Vector2Int position)
    {
        GameObject newBrick = Instantiate(brickPrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
        gridArray[position.x, position.y] = newBrick;
    }

    public void SpawnRandomBrick(GameObject brickPrefab)
    {
        GridManager gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            BrickShape randomShape = (BrickShape)Random.Range(0, System.Enum.GetValues(typeof(BrickShape)).Length);
            GameObject newBrick = Instantiate(brickPrefab);
            Brick brickComponent = newBrick.GetComponent<Brick>();

            if (brickComponent != null)
            {
                brickComponent.brickShape = randomShape;
                brickComponent.SetRelativePositions();

                Vector2Int spawnPosition = new Vector2Int(Random.Range(0, gridWidth), gridHeight - 1);

                // Check if bricks are overlapping or out of bounds
                while (CheckOverlap(brickComponent.relativePositions, spawnPosition))
                {
                    // If overlapping, recalculate spawn position
                    spawnPosition = new Vector2Int(Random.Range(0, gridWidth), gridHeight - 1);
                }

                brickComponent.SpawnOnGrid(spawnPosition);
            }
            else
            {
                Debug.LogError("Brick component not found!");
            }
        }
    }

    bool CheckOverlap(Vector2Int[] relativePositions, Vector2Int spawnPosition)
    {
        foreach (Vector2Int relativePos in relativePositions)
        {
            Vector2Int brickPos = spawnPosition + relativePos;
            // Check if the position is out of bounds or already occupied
            if (brickPos.x < 0 || brickPos.x >= gridWidth || brickPos.y < 0 || brickPos.y >= gridHeight ||
                gridArray[brickPos.x, brickPos.y] != null)
            {
                return true; // Overlapping or out of bounds
            }
        }

        return false; // No overlap
    }
}
