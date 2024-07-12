using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


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
        transform.position = tileSelection.CellToWorld(startingPosition);
        playerPosition = startingPosition;
        OnPlayerTurn();
    }

    private void OnPlayerTurn() {
        movesLeft = turnTracker.Roll6SidedDice();
        adjacentTilesToPlayer = neighbourTileFinder.FindAdjacentTiles(playerPosition, tileSelection.Tilemap);
    }

    private void OnPlayerMove() {

    }

    
    private void Update() {
        
    }
}
