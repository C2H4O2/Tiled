using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishQueenTile : EffectTile
{
    private NeighbourTileFinder neighbourTileFinder;
    private TileSelection tileSelection;
    private EffectTilePositions effectTilePositions;
    private Player[] players;
    private PlaceTiles placeTiles;
    [SerializeField] private EffectTile jellyFishClone;
    
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
                    placeTiles.PlaceTile(jellyFishClone, tilePos);
                }
            }    
        }
    }

    public override void OnRemoval()
    {
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        if(effectTilePositions.TryGetAllEffectPositionsOfType(jellyFishClone, out List<Vector2Int> positions)) {
            foreach (var position in positions) {
                effectTilePositions.EffectTilePosition.Remove(position);
                tileSelection.PlacedTiles.SetTile((Vector3Int)position, null);
            }
        }
        else {
            Debug.Log("no jellyfish clones");
        }
    }


}
