using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTiles : MonoBehaviour
{

    [SerializeField] private Tilemap boardTiles;
    [SerializeField] private Tilemap placedTiles;
    [SerializeField] private 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaceTile(Tile tileToPlace, Vector2Int tileToPlacePosition)
    {
        placedTiles.SetTile((Vector3Int)tileToPlacePosition, tileToPlace);
    }
}
