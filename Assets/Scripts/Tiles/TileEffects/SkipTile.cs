using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTile : EffectTile
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
            Debug.Log(effectTileInfo.IsFacingPositive);
            if (effectTileInfo.IsFacingPositive)
            {
                if(tileSelection.BoardTile.HasTile((Vector3Int)(landedPosition + new Vector2Int(2,0)))) {
                    targetPlayer.Respawn();
                }
                else {
                    targetPlayer.MovePlayer(landedPosition + new Vector2Int(2, 0));
                }
            }
            else
            {
                if(tileSelection.BoardTile.HasTile((Vector3Int)(landedPosition + new Vector2Int(-2,0)))) {
                    targetPlayer.Respawn();
                }
                else {
                    targetPlayer.MovePlayer(landedPosition + new Vector2Int(-2, 0));
                }
            }
        }
    }
}
