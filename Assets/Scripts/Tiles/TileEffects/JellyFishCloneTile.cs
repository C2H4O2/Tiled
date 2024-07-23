using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishCloneTile : EffectTile
{
    private NeighbourTileFinder neighbourTileFinder;
    private TileSelection tileSelection;
    private EffectTilePositions effectTilePositions;
    private Player[] players;
    private PlaceTiles placeTiles;
    public override void OnLand(Vector2Int landedPosition)
    {
        tileSelection = FindAnyObjectByType<TileSelection>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        placeTiles = FindAnyObjectByType<PlaceTiles>();
        players = FindObjectsOfType<Player>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        
        Vector2Int[] adjacentTiles = neighbourTileFinder.FindAdjacentTiles(landedPosition, tileSelection.PlacedTiles);
        foreach (var tilePos in adjacentTiles) {
            if(effectTilePositions.TryGetEffectTile(tilePos, out var effectTileInfo)) {
                if(!effectTileInfo.EffectTile.IsIndestructable) {
                    placeTiles.PlaceTile(this, tilePos);
                }
            }    
        }
    }

    
}
