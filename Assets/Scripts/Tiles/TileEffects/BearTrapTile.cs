using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BearTrapTile : EffectTile
{
    
    public override void OnLand(Vector2Int landedPosition)
    {
        TurnTracker turnTracker = FindAnyObjectByType<TurnTracker>();
        TileSelection tileSelection = FindAnyObjectByType<TileSelection>();
        EffectTilePositions effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        PlayerTilePositions playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        if(effectTilePositions.TryGetEffectTile(landedPosition, out var effectTileInfo)) {
            if(turnTracker.TeamOnePlayers.Contains(playerTilePositions.GetPlayerAtTilePosition(landedPosition)) ^ effectTileInfo.IsFacingPositive) {
                playerTilePositions.GetPlayerAtTilePosition(landedPosition).Respawn();
                effectTilePositions.EffectTilePosition.Remove(landedPosition);
                tileSelection.PlacedTiles.SetTile((Vector3Int)landedPosition, null);
            }
        }
        
    }
}
