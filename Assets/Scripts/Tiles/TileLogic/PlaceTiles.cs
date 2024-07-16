using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTiles : MonoBehaviour
{
    [SerializeField] private Tilemap boardTiles;
    [SerializeField] private Tilemap placedTiles;
    [SerializeField] private Player[] players;
    [SerializeField] private EffectTilePositions effectTilePositions;
    private void Awake() {
        players = FindObjectsOfType<Player>();
    }
    
    public void PlaceTile(EffectTile effectTile, Vector2Int tileToPlacePosition)
    {
        placedTiles.SetTile((Vector3Int)tileToPlacePosition, effectTile.TileToPlace);
        effectTilePositions.EffectTilePosition.Add(tileToPlacePosition, effectTile);
        foreach (Player player in players) {
            player.UpdateAdjacentTiles();
        }
    }

    
}
