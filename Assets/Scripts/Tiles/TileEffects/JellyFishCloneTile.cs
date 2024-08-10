using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishCloneTile : EffectTile
{
    [SerializeField] private bool chainJellyFish;
    public override void OnLand(Vector2Int landedPosition)
    {
        if (chainJellyFish) {
            TileSelection tileSelection = FindAnyObjectByType<TileSelection>();
            NeighbourTileFinder neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
            PlaceTiles placeTiles = FindAnyObjectByType<PlaceTiles>();
            EffectTilePositions effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
            Vector2Int[] adjacentTiles = neighbourTileFinder.FindAdjacentTiles(landedPosition, tileSelection.PlacedTiles);
            foreach (var tilePos in adjacentTiles) {
                if(effectTilePositions.TryGetEffectTile(tilePos, out var effectTileInfo)) {
                    if(!effectTileInfo.EffectTile.IsIndestructable) {
                        placeTiles.PlaceTile(this.GetComponent<EffectTile>(), tilePos);
                    }
                }    
        }
        }
    }

    
}
