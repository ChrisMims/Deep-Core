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
}
