using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishTile : EffectTile
{
    private NeighbourTileFinder neighbourTileFinder;
    private TileSelection tileSelection;
    private Player[] players;
    private PlaceTiles placeTiles;
    public override void OnLand(Vector2Int landedPosition)
    {
        tileSelection = FindAnyObjectByType<TileSelection>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        placeTiles = FindAnyObjectByType<PlaceTiles>();
        players = FindObjectsOfType<Player>();
        
        Vector2Int[] adjacentTiles = neighbourTileFinder.FindAdjacentTiles(landedPosition, tileSelection.PlacedTiles);
        foreach (var tile in adjacentTiles) {
            placeTiles.PlaceTile(this, tile);
        }
    }

    
}
