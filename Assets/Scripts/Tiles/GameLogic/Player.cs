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
    private DragTiles dragTiles;
    


    public string NameTag { get => nameTag; }

    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        tileSelection = FindAnyObjectByType<TileSelection>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        dragTiles = FindAnyObjectByType<DragTiles>();
    }
    private void Start() {
        MovePlayer(startingPosition);
    }

    private void Update() {
        if(turnTracker.QueryTurn() == this && Input.GetMouseButtonUp(0) && turnTracker.MovesLeft != 0) {
            UpdateAdjacentTiles();
            
            if(adjacentTilesToPlayer.Contains(tileSelection.HighlightedTilePosition)){
                if(dragTiles.DraggingTile) {

                }
                Debug.Log("Move to" + tileSelection.HighlightedTilePosition);
                MovePlayer(tileSelection.HighlightedTilePosition);
                turnTracker.MovesLeft-=1;
                UpdateAdjacentTiles();
            }
        }

        if(turnTracker.MovesLeft <= 0 && turnTracker.QueryTurn() == this) {
            Debug.Log("Switch turns");
            turnTracker.CycleThroughTurn();
        }   
    }

    private void MovePlayer(Vector2Int cellPosition) {
        transform.position = tileSelection.CellToWorld(cellPosition);
        playerPosition = cellPosition;
    }

    private void UpdateAdjacentTiles() {
        adjacentTilesToPlayer = neighbourTileFinder.FindAdjacentTiles(playerPosition, tileSelection.Tilemap);
    }
}
