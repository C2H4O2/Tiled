using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTiles : MonoBehaviour
{
    [SerializeField] private Tilemap boardTiles;
    [SerializeField] private Tilemap placedTiles;
    [SerializeField] private Player[] players;
    private DeckGenerator deckGenerator;
    private EffectTilePositions effectTilePositions;
    private void Awake() {
        players = FindObjectsOfType<Player>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        deckGenerator = FindAnyObjectByType<DeckGenerator>();
    }
    
    public void PlaceTile(EffectTile effectTile, Vector2Int tileToPlacePosition)
    {
        placedTiles.SetTile((Vector3Int)tileToPlacePosition, effectTile.TileToPlace);
        effectTilePositions.EffectTilePosition.Add(tileToPlacePosition, deckGenerator.GetTileByEffectTile(effectTile).GetComponent<EffectTile>());
        foreach (Player player in players) {
            player.UpdateAdjacentTiles();
        }
    }

    
}
