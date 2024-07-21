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

    public void PlaceTile(EffectTile effectTile, Vector2Int tileToPlacePosition)
    {
        bool isFacingPositive = true;
        placedTiles.SetTile((Vector3Int)tileToPlacePosition, effectTile.TileToPlace);
        if(effectTile.IsDirectional && turnTracker.TeamTwoPlayers.Contains(turnTracker.QueryTurn())) {
            var matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(-1, 1, 1));
            placedTiles.SetTransformMatrix((Vector3Int)tileToPlacePosition, matrix);
            isFacingPositive = false;
        }
        
        effectTilePositions.EffectTilePosition.Remove(tileToPlacePosition);
        effectTilePositions.AddEffectTile(tileToPlacePosition, deckGenerator.GetTileByEffectTile(effectTile).GetComponent<EffectTile>(), isFacingPositive);
        for (int i = 0; i < players.Length; i++) {
            if(tileToPlacePosition == players[i].PlayerPosition) {
                players[i].MovePlayer(tileToPlacePosition);
            }
        }
        
        foreach (Player player in players) {
            player.UpdateAdjacentTiles();
        }
    }

    
}
