using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkipTile : EffectTile
{
    private PlayerTilePositions playerTilePositions;
    private EffectTilePositions effectTilePositions;
    private TurnTracker turnTracker;
    public override void OnLand(Vector2Int landedPosition)
    {
        playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        turnTracker = FindAnyObjectByType<TurnTracker>();

        Player targetPlayer = playerTilePositions.GetPlayerAtTilePosition(landedPosition);
        if(effectTilePositions.TryGetEffectTile(landedPosition, out var effectTileInfo)) {
            
            if(effectTileInfo.IsFacingPositive) {
                targetPlayer.MovePlayer(landedPosition+new Vector2Int(2, 0));
            }
        }
        else
            targetPlayer.MovePlayer(landedPosition+new Vector2Int(-2, 0));
    }

}
