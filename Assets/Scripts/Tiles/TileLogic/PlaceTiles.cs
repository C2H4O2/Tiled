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

    public void PlaceTile(EffectTile effectTile, Vector2Int tileToPlacePosition, bool triggerEffect = true, bool? isFacingPositive = true, bool initialise = false) 
    {
        Vector3Int tilemapPosition = (Vector3Int)tileToPlacePosition;
        placedTiles.SetTransformMatrix(tilemapPosition, Matrix4x4.identity);
        placedTiles.SetTile(tilemapPosition, effectTile.TileToPlace);

        if (effectTile.IsDirectional) 
        {
            if (isFacingPositive == null) 
            {
                isFacingPositive = !turnTracker.TeamTwoPlayers.Contains(turnTracker.QueryTurn());
            }

            if (effectTile.BlueTile == null && effectTile.RedTile == null && isFacingPositive == false) 
            {
                // Flip the tile if no specific variants are available
                var matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(-1, 1, 1));
                placedTiles.SetTransformMatrix(tilemapPosition, matrix);
            } 
            else if (effectTile.BlueTile != null && isFacingPositive == true) 
            {
                // Place blue tile facing positive
                placedTiles.SetTile(tilemapPosition, effectTile.BlueTile);
            } 
            else if (effectTile.RedTile != null && isFacingPositive == false) 
            {
                // Place red tile not facing positive
                placedTiles.SetTile(tilemapPosition, effectTile.RedTile);
                var matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(-1, 1, 1));
                placedTiles.SetTransformMatrix(tilemapPosition, matrix);
            }
        }

        effectTilePositions.EffectTilePosition.Remove(tileToPlacePosition);
        effectTilePositions.AddEffectTile(tileToPlacePosition, deckGenerator.GetTileByEffectTile(effectTile).GetComponent<EffectTile>(), isFacingPositive.Value);

        if (triggerEffect) 
        {
            foreach (var player in players) 
            {
                if (tileToPlacePosition == player.PlayerPosition) 
                {
                    player.MovePlayer(tileToPlacePosition, 0f);
                }
            }
        }

        foreach (Player player in players) 
        {
            player.UpdateAdjacentTiles();
        }
    }
}
