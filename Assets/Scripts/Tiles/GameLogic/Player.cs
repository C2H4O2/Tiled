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
    private PlayerTilePositions playerTilePositions;

    public string NameTag { get => nameTag; }
    public Vector2Int PlayerPosition { get => playerPosition; }

    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        tileSelection = FindAnyObjectByType<TileSelection>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
    }
    private void Start() {
        MovePlayer(startingPosition);
        UpdateAdjacentTiles();
    }

    private void Update() {
        if(CanMove()) {
            Debug.Log("Move to" + tileSelection.HighlightedTilePosition);
            MovePlayer(tileSelection.HighlightedTilePosition);
            turnTracker.MovesLeft-=1;
            UpdateAdjacentTiles();
            playerTilePositions.UpdateAllPlayerTilePositions();
        }
        
        if(turnTracker.MovesLeft <= 0 && turnTracker.QueryTurn() == this) {
            StartCoroutine(DelayForSeconds(1f));
            Debug.Log("Switch turns");
            turnTracker.CycleThroughTurn();
        }   
    }
    private bool CanMove() {
        if(!(turnTracker.QueryTurn() == this)) 
            return false;
        if(turnTracker.MovesLeft <= 0)
            return false;
        if(!Input.GetMouseButtonUp(0))
            return false;
        if(turnTracker.DraggingTile)
            return false;
        if(!adjacentTilesToPlayer.Contains(tileSelection.HighlightedTilePosition))
            return false;
        if(playerTilePositions.PlayerPositions.Contains(tileSelection.HighlightedTilePosition))
            return false;
        else return true;

    }

    private IEnumerator DelayForSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
    }

    private void MovePlayer(Vector2Int cellPosition) {
        transform.position = tileSelection.CellToWorld(cellPosition);
        playerPosition = cellPosition;
    }

    public void UpdateAdjacentTiles() {
        adjacentTilesToPlayer = neighbourTileFinder.FindAdjacentTiles(playerPosition, tileSelection.PlacedTiles);
    }
}
