using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPopperTile : EffectTile
{
    private EffectTilePositions effectTilePositions;
    private PlaceTiles placeTiles;
    public override void OnLand(Vector2Int landedPosition) {
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        placeTiles =FindAnyObjectByType<PlaceTiles>();
        effectTilePositions.ScrambleEffectTiles();
        foreach (var key in effectTilePositions.EffectTilePosition.Keys)
        {
            if(effectTilePositions.TryGetEffectTile(key, out var effectTileInfo))
            placeTiles.PlaceTile(effectTileInfo.EffectTile, key);
        }
    }
}
