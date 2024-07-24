using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPopperTile : EffectTile
{
    private EffectTilePositions effectTilePositions;
    private PlaceTiles placeTiles;

    public override void OnLand(Vector2Int landedPosition) {
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        placeTiles = FindAnyObjectByType<PlaceTiles>();
        
        effectTilePositions.ScrambleEffectTiles();

        List<Vector2Int> keys = new List<Vector2Int>(effectTilePositions.EffectTilePosition.Keys);

        foreach (var key in keys)
        {
            if (effectTilePositions.TryGetEffectTile(key, out var effectTileInfo))
                placeTiles.PartyPopperPlace(effectTileInfo.EffectTile, key, effectTileInfo.IsFacingPositive);
        }
    }
}
