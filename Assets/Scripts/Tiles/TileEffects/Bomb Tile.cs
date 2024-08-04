using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombTile : EffectTile
{

    public override void OnLand(Vector2Int tilePosition)
    {
        TileSelection tileSelection = FindAnyObjectByType<TileSelection>();
        PlayerTilePositions playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        NeighbourTileFinder neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        EffectTilePositions effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        TurnTracker turnTracker = FindAnyObjectByType<TurnTracker>();
        if(playerTilePositions.GetPlayerAtTilePosition(tilePosition) == turnTracker.QueryTurn()) {
            turnTracker.CycleThroughTurn();
        }
        playerTilePositions.GetPlayerAtTilePosition(tilePosition).Respawn();
        foreach (var adjacentTile in neighbourTileFinder.FindAdjacentTiles(tilePosition, tileSelection.BoardTile))
        {
            if (effectTilePositions.TryGetEffectTile(adjacentTile, out var effectTileInfo)) {
                if(!effectTileInfo.EffectTile.IsIndestructable) {
                    if (!playerTilePositions.StartingPositions.Contains(adjacentTile)) {
                        tileSelection.PlacedTiles.SetTile((Vector3Int)adjacentTile, null);
                        effectTilePositions.EffectTilePosition.Remove(adjacentTile);
                    }
                }
            }
            
            if(playerTilePositions.GetPlayerAtTilePosition(adjacentTile) != null)
                playerTilePositions.GetPlayerAtTilePosition(adjacentTile).Respawn();
        }
        tileSelection.PlacedTiles.SetTile((Vector3Int)tilePosition, null);
        effectTilePositions.EffectTilePosition.Remove(tilePosition);
        
    }
}
