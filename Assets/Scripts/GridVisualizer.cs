using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisualizer : MonoBehaviour
{
    [SerializeField]
    GridSystem gridSystem;

    [SerializeField]
    Tile tilePrefab;

    [SerializeField]
    private float tileSize;

    void Awake()
    {
        gridSystem.GridCreated += OnGridCreated;
    }

    private void OnGridCreated()
    {
        for (int i = 0; i < gridSystem.Tiles.GetLength(0); i++)
        {
            for (int j = 0; j < gridSystem.Tiles.GetLength(1); j++)
            {
                var tile = Instantiate(tilePrefab, transform);
                tile.transform.localPosition = new Vector3(i * tileSize, 0, j * tileSize);
                tile.TileData = gridSystem.Tiles[i, j];
            }
        }
    }
}
