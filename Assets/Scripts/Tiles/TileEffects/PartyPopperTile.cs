using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPopperTile : EffectTile
{
    public override void OnLand(Vector2Int landedPosition) {
        EffectTilePositions effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        PlaceTiles placeTiles = FindAnyObjectByType<PlaceTiles>();
        
        effectTilePositions.ScrambleEffectTiles();

        List<Vector2Int> keys = new List<Vector2Int>(effectTilePositions.EffectTilePosition.Keys);

        foreach (var key in keys)
        {
            if (effectTilePositions.TryGetEffectTile(key, out var effectTileInfo))
                placeTiles.PlaceTile(effectTileInfo.EffectTile, key, false, effectTileInfo.IsFacingPositive);
        }
    }
}
