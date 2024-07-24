using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTiles : MonoBehaviour
{
    [SerializeField] private Tilemap boardTiles;
    [SerializeField] private Tilemap placedTiles;
    [SerializeField] private Player[] players;
    private DeckGenerator deckGenerator;
    private EffectTilePositions effectTilePositions;
    private TurnTracker turnTracker;
    private void Awake() {
        players = FindObjectsOfType<Player>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        deckGenerator = FindAnyObjectByType<DeckGenerator>();
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }

    public void PlaceTile(EffectTile effectTile, Vector2Int tileToPlacePosition, bool triggerEffect)
    {
        bool isFacingPositive = true;
        Vector3Int tilemapPosition = (Vector3Int)tileToPlacePosition;
        
        // Reset the transformation matrix at the position
        placedTiles.SetTransformMatrix(tilemapPosition, Matrix4x4.identity);
        
        placedTiles.SetTile(tilemapPosition, effectTile.TileToPlace);

        if (effectTile.IsDirectional)
        {
            bool isTeamTwo = turnTracker.TeamTwoPlayers.Contains(turnTracker.QueryTurn());

            if (isTeamTwo)
            {
                isFacingPositive = false;
            }

            if (effectTile.BlueTile == null && effectTile.RedTile == null && isTeamTwo)
            {
                // Flip the tile if no specific variants are available
                var matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(-1, 1, 1));
                placedTiles.SetTransformMatrix(tilemapPosition, matrix);
            }
            else if (effectTile.BlueTile != null && !isTeamTwo)
            {
                // Place blue tile facing positive
                placedTiles.SetTile(tilemapPosition, effectTile.BlueTile);
            }
            else if (effectTile.RedTile != null && isTeamTwo)
            {
                // Place red tile not facing positive
                placedTiles.SetTile(tilemapPosition, effectTile.RedTile);
                var matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(-1, 1, 1));
                placedTiles.SetTransformMatrix(tilemapPosition, matrix);
            }
        }

        effectTilePositions.EffectTilePosition.Remove(tileToPlacePosition);
        effectTilePositions.AddEffectTile(tileToPlacePosition, deckGenerator.GetTileByEffectTile(effectTile).GetComponent<EffectTile>(), isFacingPositive);

        if (triggerEffect)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (tileToPlacePosition == players[i].PlayerPosition)
                {
                    players[i].MovePlayer(tileToPlacePosition);
                }
            }
        }

        foreach (Player player in players)
        {
            player.UpdateAdjacentTiles();
        }
    }

    public void PartyPopperPlace(EffectTile effectTile, Vector2Int tileToPlacePosition, bool isFacingPositive) {
        Vector3Int tilemapPosition = (Vector3Int)tileToPlacePosition;
        
        // Reset the transformation matrix at the position
        placedTiles.SetTransformMatrix(tilemapPosition, Matrix4x4.identity);
        
        placedTiles.SetTile(tilemapPosition, effectTile.TileToPlace);

        if (effectTile.IsDirectional)
        {

            if (effectTile.BlueTile == null && effectTile.RedTile == null && !isFacingPositive)
            {
                // Flip the tile if no specific variants are available
                var matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(-1, 1, 1));
                placedTiles.SetTransformMatrix(tilemapPosition, matrix);
            }
            else if (effectTile.BlueTile != null && isFacingPositive)
            {
                // Place blue tile facing positive
                placedTiles.SetTile(tilemapPosition, effectTile.BlueTile);
            }
            else if (effectTile.RedTile != null && !isFacingPositive)
            {
                // Place red tile not facing positive
                placedTiles.SetTile(tilemapPosition, effectTile.RedTile);
                var matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(-1, 1, 1));
                placedTiles.SetTransformMatrix(tilemapPosition, matrix);
            }
        }

        effectTilePositions.EffectTilePosition.Remove(tileToPlacePosition);
        effectTilePositions.AddEffectTile(tileToPlacePosition, deckGenerator.GetTileByEffectTile(effectTile).GetComponent<EffectTile>(), isFacingPositive);


        foreach (Player player in players)
        {
            player.UpdateAdjacentTiles();
        }
    }
    
}
