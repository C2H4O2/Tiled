using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinTile : EffectTile
{
    [SerializeField] private List<EffectTile> invalidTiles;
    public override void OnLand(Vector2Int landedPosition)
    {
        EffectTilePositions effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        TileSelection tileSelection = FindAnyObjectByType<TileSelection>();
        PlayerTilePositions playerTilePositions= FindAnyObjectByType<PlayerTilePositions>();
        Player targetPlayer = playerTilePositions.GetPlayerAtTilePosition(landedPosition);
        int sign = 1;
        if(effectTilePositions.TryGetEffectTile(landedPosition, out var effectTileInfo)) {
            if(!effectTileInfo.IsFacingPositive) {
                sign = -1;
            }
            Vector2Int targetPosition = landedPosition;
            while (tileSelection.PlacedTiles.HasTile((Vector3Int)(targetPosition + new Vector2Int(sign*1,0))))
            {
                if(effectTilePositions.TryGetEffectTile(targetPosition, out var effectTileInfoNext)) {
                    if(effectTileInfoNext.EffectTile.IsTrap) {
                        break;
                    }
                }
                targetPosition += new Vector2Int(sign*1,0);
            }
            if(effectTilePositions.TryGetEffectTile(targetPosition, out var effectTileInfoEnd)) {
                if(invalidTiles.Contains(effectTileInfoEnd.EffectTile) && (effectTileInfoEnd.IsFacingPositive != effectTileInfo.IsFacingPositive) ) {
                    targetPlayer.MovePlayerWithoutTriggeringEffect(targetPosition, 0.2f);
                }
                else {
                    targetPlayer.MovePlayer(targetPosition, 0.2f, 0);
                }
                //fix jump tile and penguin interaction
            }
            
        }
    }
}
