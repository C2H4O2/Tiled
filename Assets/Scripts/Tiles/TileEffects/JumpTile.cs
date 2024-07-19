using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTile : EffectTile
{
    private PlayerTilePositions playerTilePositions;
    private EffectTilePositions effectTilePositions;
    private TileSelection tileSelection;

    public override void OnLand(Vector2Int landedPosition)
    {
        playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        tileSelection = FindAnyObjectByType<TileSelection>();

        Player targetPlayer = playerTilePositions.GetPlayerAtTilePosition(landedPosition);

        if (targetPlayer == null)
        {
            Debug.LogWarning($"No player found at position {landedPosition}");
            return;
        }

        if (effectTilePositions.TryGetEffectTile(landedPosition, out var effectTileInfo))
        {
            int sign = 1;
            if(!effectTileInfo.IsFacingPositive) {
                sign = -1;
            }
            if(effectTilePositions.TryGetEffectTile(landedPosition + new Vector2Int(sign*2,0), out var effectTileInfoForLanding)) {
                if(effectTileInfoForLanding.IsFacingPositive != effectTileInfo.IsFacingPositive) {
                    Debug.Log("You skipped and unskipped?");
                    return;
                }
            }
            if(tileSelection.BoardTile.HasTile((Vector3Int)(landedPosition + new Vector2Int(sign*2,0)))) {
                targetPlayer.MovePlayer(landedPosition + new Vector2Int(sign*2, 0));
            }
            else {
                targetPlayer.Respawn();
            }
            
        }
    }
}
