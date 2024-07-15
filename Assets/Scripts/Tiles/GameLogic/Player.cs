using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private string nameTag;
    [SerializeField] private Vector2Int startingPosition;
    [SerializeField] private Vector2Int playerPosition;
    [SerializeField] private Vector2Int[] adjacentTilesToPlayer;
    
    private TurnTracker turnTracker;
    private TileSelection tileSelection;
    private NeighbourTileFinder neighbourTileFinder;

    public string NameTag { get => nameTag; }
    public Vector2Int[] AdjacentTilesToPlayer { get => adjacentTilesToPlayer; }

    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        tileSelection = FindAnyObjectByType<TileSelection>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
    }
    private void Start() {
        MovePlayer(startingPosition);
        UpdateAdjacentTiles();
    }

    private void Update() {
        if(turnTracker.QueryTurn() == this && Input.GetMouseButtonUp(0) && turnTracker.MovesLeft != 0 && !turnTracker.DraggingTile) {
            if(adjacentTilesToPlayer.Contains(tileSelection.HighlightedTilePosition)){
                Debug.Log("Move to" + tileSelection.HighlightedTilePosition);
                MovePlayer(tileSelection.HighlightedTilePosition);
                turnTracker.MovesLeft-=1;
                UpdateAdjacentTiles();
            }
        }
        
        if(turnTracker.MovesLeft <= 0 && turnTracker.QueryTurn() == this) {
            StartCoroutine(DelayForSeconds(1f));
            Debug.Log("Switch turns");
            turnTracker.CycleThroughTurn();
        }   
    }

    private IEnumerator DelayForSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
    }

    private void MovePlayer(Vector2Int cellPosition) {
        transform.position = tileSelection.CellToWorld(cellPosition);
        playerPosition = cellPosition;
    }

    private void UpdateAdjacentTiles() {
        adjacentTilesToPlayer = neighbourTileFinder.FindAdjacentTiles(playerPosition, tileSelection.Tilemap);
    }
}
