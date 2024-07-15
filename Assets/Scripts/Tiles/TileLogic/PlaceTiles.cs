using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTiles : MonoBehaviour
{
    [SerializeField] private Tilemap boardTiles;
    [SerializeField] private Tilemap placedTiles;
    [SerializeField] private Player[] players;
    private void Awake() {
        players = FindObjectsOfType<Player>();
    }
    
    public void PlaceTile(Tile tileToPlace, Vector2Int tileToPlacePosition)
    {
        placedTiles.SetTile((Vector3Int)tileToPlacePosition, tileToPlace);
        foreach (Player player in players) {
            player.UpdateAdjacentTiles();
        }
    }

    
}
