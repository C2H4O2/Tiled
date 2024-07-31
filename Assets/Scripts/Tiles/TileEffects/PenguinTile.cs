using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinTile : EffectTile
{
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
                if(effectTileInfoEnd.EffectTile == effectTileInfo.EffectTile) {
                    targetPlayer.MovePlayerWithoutTriggeringEffect(targetPosition, 0.2f);
                }
                else {
                    targetPlayer.MovePlayer(targetPosition, 0.2f, 0);
                }
            }
            
        }
    }

    //check if tile 1 tile is not empty
    //if empty then stop sliding
    // if not empty and is a trap then activate effect
    // if not empty then loop

   
}
