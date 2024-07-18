using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTile : EffectTile
{
    private PlayerTilePositions playerTilePositions;
    private EffectTilePositions effectTilePositions;
    private TurnTracker turnTracker;

    public override void OnLand(Vector2Int landedPosition)
    {
        playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        turnTracker = FindAnyObjectByType<TurnTracker>();

        Player targetPlayer = playerTilePositions.GetPlayerAtTilePosition(landedPosition);

        if (targetPlayer == null)
        {
            Debug.LogWarning($"No player found at position {landedPosition}");
            return;
        }

        if (effectTilePositions.TryGetEffectTile(landedPosition, out var effectTileInfo))
        {
            Debug.Log(effectTileInfo.IsFacingPositive);
            if (effectTileInfo.IsFacingPositive)
            {
                targetPlayer.MovePlayer(landedPosition + new Vector2Int(2, 0));
            }
            else
            {
                targetPlayer.MovePlayer(landedPosition + new Vector2Int(-2, 0));
            }
        }
        else
        {
            targetPlayer.MovePlayer(landedPosition + new Vector2Int(-2, 0));
        }
    }
}
