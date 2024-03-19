using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileData TileData;

    public GameObject buildingPrefab;

    internal void Build(GameObject prefab)
    {
        var bld = Instantiate(prefab, transform);
        bld.transform.localPosition = Vector3.zero;
        TileData.isOccupied = true;
    }

    private void OnMouseDown()
    {
        CommandQueue.Instance.EnqueueCommand(new BuildCommand() { 
            prefab = buildingPrefab, 
            tile = this
        });
    }
}
