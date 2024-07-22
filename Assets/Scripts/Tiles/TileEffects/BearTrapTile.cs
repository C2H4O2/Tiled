using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BearTrapTile : EffectTile
{
    private TurnTracker turnTracker;
    private EffectTilePositions effectTilePositions;
    private PlayerTilePositions playerTilePositions;
    public override void OnLand(Vector2Int landedPosition)
    {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        Player targetPlayer = turnTracker.QueryTurn();
        if(effectTilePositions.TryGetEffectTile(landedPosition, out var effectTileInfo)) {
            if(turnTracker.TeamOnePlayers.Contains(playerTilePositions.GetPlayerAtTilePosition(landedPosition)) ^ effectTileInfo.IsFacingPositive) {
                playerTilePositions.GetPlayerAtTilePosition(landedPosition).Respawn();
            }
        }
    }
}
