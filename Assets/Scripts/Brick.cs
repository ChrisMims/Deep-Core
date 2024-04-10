using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickShape
{
    SquareShape,
    LineShape,
    LShape,
    TShape,
    NShape,
}
public class Brick : MonoBehaviour
{
    public BrickShape brickShape;

    public Vector2Int[] relativePositions;
    void Start()
    {
        SetRelativePositions();
        SpawnOnGrid();
    }

    void SetRelativePositions()
    {
        switch (brickShape)
        {
            case BrickShape.SquareShape:
                relativePositions = new Vector2Int[]
                {
                    // Defines the center of the shape
                    new Vector2Int(0, 0),
                    // One unit to the right
                    new Vector2Int(1, 0),
                    // One unit above
                    new Vector2Int(0, 1),
                    // One unit diagonally up and right
                    new Vector2Int(1, 1),

                    // Brick visualized:
                    // [ ] [ ]
                    // [ ] [ ]
                };
                break;
            case BrickShape.LineShape:
                relativePositions = new Vector2Int[]
                {

                    // Brick visualized:
                    // [ ]
                    // [ ]
                    // [ ]
                    // [ ]
                };
                break;
            case BrickShape.LShape:
                relativePositions = new Vector2Int[]
                {

                    // Brick visualized:
                    // [ ]
                    // [ ]
                    // [ ] [ ]
                };
                break;
            case BrickShape.TShape:
                relativePositions = new Vector2Int[]
                {

                    // Brick visualized:
                    //     [ ]
                    // [ ] [ ] [ ]
                };
                break;
            case BrickShape.NShape:
                relativePositions = new Vector2Int[]
                {

                    // Brick visualized:
                    //     [ ] [ ]
                    // [ ] [ ]
                };
                break;
            
        }
    }

    void SpawnOnGrid()
    {
        GridManager gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            Vector2Int spawnPosition = new Vector2Int(gridManager.gridWidth / 2, gridManager.gridHeight - 1);
            spawnPosition -= new Vector2Int(1, 0);

            foreach (Vector2Int relativePos in relativePositions)
            {
                Vector2Int brickPos = spawnPosition + relativePos;
                gridManager.SpawnBrick(gameObject, brickPos);
            }
        }
        else
        {
            Debug.LogError("GridManager not found!");
        }
    }
}
