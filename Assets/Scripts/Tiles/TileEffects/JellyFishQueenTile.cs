using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishQueenTile : EffectTile
{
    private NeighbourTileFinder neighbourTileFinder;
    private TileSelection tileSelection;
    private EffectTilePositions effectTilePositions;
    private PlaceTiles placeTiles;
    [SerializeField] private EffectTile jellyFishClone;
    
    public override void OnLand(Vector2Int landedPosition)
    {
        tileSelection = FindAnyObjectByType<TileSelection>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        placeTiles = FindAnyObjectByType<PlaceTiles>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        Vector2Int[] adjacentTiles = neighbourTileFinder.FindAdjacentTiles(landedPosition, tileSelection.PlacedTiles);
        foreach (var tilePos in adjacentTiles) {
            if(effectTilePositions.TryGetEffectTile(tilePos, out var effectTileInfo)) {
                if(!effectTileInfo.EffectTile.IsIndestructable) {
                    placeTiles.PlaceTile(jellyFishClone, tilePos);
                }
            }    
        }
    }
}
