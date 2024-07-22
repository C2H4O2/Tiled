using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPopperTile : EffectTile
{
    private EffectTilePositions effectTilePositions;
    private TileSelection tileSelection;
    public override void OnLand(Vector2Int landedPosition) {
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        tileSelection = FindAnyObjectByType<TileSelection>();
        effectTilePositions.ScrambleEffectTiles();
        foreach (var key in effectTilePositions.EffectTilePosition.Keys)
        {
            if(effectTilePositions.TryGetEffectTile(key, out var effectTileInfo))
            tileSelection.PlacedTiles.SetTile((Vector3Int)key, effectTileInfo.EffectTile.TileToPlace);
        }
    }
}
