using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int rows = 5;
    [SerializeField] private int cols = 5;
    [SerializeField] private float tileSize = 1f;
    
    void Start()
    {
        GenerateGrids();
    }

    // There will be two for loops to generate rows and colums under the limits
    public void GenerateGrids()
    {
        // before the loops lets instantiate grids from the Resources file in Unity to point Reference Tile to create tile
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("InventorySlot"));

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < rows; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float positionX = col * tileSize;
                float positionY = row * -tileSize;

                tile.transform.position = new Vector2(positionX, positionY);
            }
        }

        // We just wanted to take it as a reference so we could destroy it
        Destroy(referenceTile);

        //To make it on center instead of right down corner
        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        transform.position = new Vector2(-gridW/2 + tileSize/2 , gridH/2 - tileSize/2);
    }

}
