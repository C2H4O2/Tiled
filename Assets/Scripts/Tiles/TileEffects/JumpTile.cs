using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTile : EffectTile
{
    [SerializeField] private int moveDistance;
    public override void OnLand(Vector2Int landedPosition)
    {
        PlayerTilePositions playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        EffectTilePositions effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        TileSelection tileSelection = FindAnyObjectByType<TileSelection>();

        Player targetPlayer = playerTilePositions.GetPlayerAtTilePosition(landedPosition);

        if (targetPlayer == null)
        {
            Debug.LogWarning($"No player found at position {landedPosition}");
            return;
        }

        if (effectTilePositions.TryGetEffectTile(landedPosition, out var effectTileInfo))
        {
            int sign = effectTileInfo.IsFacingPositive ? 1 : -1;
            Vector2Int targetPosition = landedPosition + new Vector2Int(sign * moveDistance , 0);
            if (effectTilePositions.TryGetEffectTile(targetPosition, out var effectTileInfoForLanding))
            {
                if (effectTileInfoForLanding.EffectTile == effectTileInfo.EffectTile && (effectTileInfo.IsFacingPositive != effectTileInfoForLanding.IsFacingPositive))
                {
                    Debug.Log("You skipped and unskipped?");
                    return;
                }
            }
            if(tileSelection.PlacedTiles.HasTile((Vector3Int)(landedPosition + new Vector2Int(sign * moveDistance , 0)))) {
                if(playerTilePositions.GetPlayerAtTilePosition(targetPosition) != null) {
                    playerTilePositions.GetPlayerAtTilePosition(targetPosition).Respawn();
                }
                targetPlayer.MovePlayer(landedPosition + new Vector2Int(sign * moveDistance, 0), 0.2f, 0);
            }
            else {
                targetPlayer.Respawn();
            }
            
            
        }
        playerTilePositions.UpdateAllPlayerTilePositions();
    }
}
