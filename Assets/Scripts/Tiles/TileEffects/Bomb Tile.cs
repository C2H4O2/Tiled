using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombTile : EffectTile
{
    private TileSelection tileSelection;
    private PlayerTilePositions playerTilePositions;
    private NeighbourTileFinder neighbourTileFinder;
    private EffectTilePositions effectTilePositions;
    public override void OnLand(Vector2Int tilePosition)
    {
        tileSelection = FindAnyObjectByType<TileSelection>();
        playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        
        playerTilePositions.GetPlayerAtTilePosition(tilePosition).Respawn();
        foreach (var adjacentTile in neighbourTileFinder.FindAdjacentTiles(tilePosition, tileSelection.BoardTile))
        {
            if (!playerTilePositions.StartingPositions.Contains(adjacentTile))
            tileSelection.PlacedTiles.SetTile((Vector3Int)adjacentTile, null);
            effectTilePositions.EffectTilePosition.Remove(adjacentTile);
        }
        //tileSelection.PlacedTiles.SetTile((Vector3Int)tilePosition, null);
        
    }
}
