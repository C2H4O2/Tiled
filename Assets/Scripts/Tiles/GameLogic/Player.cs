using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2Int startingPosition;
    [SerializeField] private Vector2Int playerPosition;
    [SerializeField] private int movesLeft;
    [SerializeField] private Vector2Int[] adjacentTilesToPlayer;
   
    private TurnTracker turnTracker;
    private TileSelection tileSelection;
    private NeighbourTileFinder neighbourTileFinder;
    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        tileSelection = FindAnyObjectByType<TileSelection>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
    }
    private void Start() {
        RefreshTurns();
        MovePlayer(startingPosition);
    }

    private void Update() {
        if(turnTracker.QueryTurn() == this && Input.GetMouseButtonDown(0) && movesLeft != 0) {
            UpdateAdjacentTiles();
            
            if(adjacentTilesToPlayer.Contains(tileSelection.HighlightedTilePosition)){
                Debug.Log("Move to" + tileSelection.HighlightedTilePosition);
                MovePlayer(tileSelection.HighlightedTilePosition);
                movesLeft-=1;
                UpdateAdjacentTiles();
            }
        }

        if(movesLeft <= 0 && turnTracker.QueryTurn() == this) {
            Debug.Log("Switch turns");
            turnTracker.CycleThroughTurn();
            RefreshTurns();
        }   
    }

    private void MovePlayer(Vector2Int cellPosition) {
        transform.position = tileSelection.CellToWorld(cellPosition);
        playerPosition = cellPosition;
    }

    private void OnPlayerTurn() {
        movesLeft = turnTracker.RollDice(6);
        adjacentTilesToPlayer = neighbourTileFinder.FindAdjacentTiles(playerPosition, tileSelection.Tilemap);
    }

    private void UpdateAdjacentTiles() {
        adjacentTilesToPlayer = neighbourTileFinder.FindAdjacentTiles(playerPosition, tileSelection.Tilemap);
    }

    private void RefreshTurns() {
        movesLeft = turnTracker.RollDice(6);
    }
}
