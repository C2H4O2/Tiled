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
    [SerializeField] private Vector2Int previousPlayerPosition;
    [SerializeField] private Vector2Int[] adjacentTilesToPlayer;
    private bool initialised = false;
    
    private TurnTracker turnTracker;
    private TileSelection tileSelection;
    private NeighbourTileFinder neighbourTileFinder;
    private PlayerTilePositions playerTilePositions;
    private EffectTilePositions effectTilePositions;
    private PlayerInventory playerInventory;

    public string NameTag { get => nameTag; }
    public Vector2Int PlayerPosition { get => playerPosition; }
    public PlayerInventory PlayerInventory { get => playerInventory; set => playerInventory = value; }
    public Vector2Int StartingPosition { get => startingPosition; }
    
    public Vector2Int PreviousPlayerPosition { get => previousPlayerPosition; set => previousPlayerPosition = value; }
    public bool Initialised { get => initialised; set => initialised = value; }

    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        tileSelection = FindAnyObjectByType<TileSelection>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        playerInventory = GetComponent<PlayerInventory>();
    }
    
    private void Start() {
        Respawn();
        UpdateAdjacentTiles();
    }

    private void Update() {
        if(CanMove()) {
            MovePlayer(tileSelection.HighlightedTilePosition, 0.2f);
        }
        
        if(turnTracker.MovesLeft <= 0 && turnTracker.QueryTurn() == this) {
            StartCoroutine(DelayForSeconds(1f));
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
        return true;
    }

    private IEnumerator DelayForSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
    }

    public void MovePlayer(Vector2Int cellPosition, float timeToMove, int moveDecrease = 1) {
        previousPlayerPosition = playerPosition;
        transform.LeanMove(tileSelection.CellToWorld(cellPosition), timeToMove).setEaseOutCirc().setOnComplete(() => {
        playerPosition = cellPosition;
        playerTilePositions.UpdateAllPlayerTilePositions();

        if (effectTilePositions.TryGetEffectTile(cellPosition, out var effectTileInfo)) {
            effectTileInfo.EffectTile.OnLand(cellPosition);
        } else {
            Debug.LogWarning($"No effect tile to land on at {cellPosition}");
        }

        turnTracker.MovesLeft -= moveDecrease;
        UpdateAdjacentTiles();
        playerTilePositions.UpdateAllPlayerTilePositions();
    });
}


    public void MovePlayerWithoutTriggeringEffect(Vector2Int cellPosition, float timeToMove) {
        previousPlayerPosition = playerPosition;
        transform.LeanMove(tileSelection.CellToWorld(cellPosition), timeToMove).setEaseOutCirc().setOnComplete(() => {
            playerPosition = cellPosition;
            playerTilePositions.UpdateAllPlayerTilePositions();
        });
    }

    public void UpdateAdjacentTiles() {
        adjacentTilesToPlayer = neighbourTileFinder.FindAdjacentTiles(playerPosition, tileSelection.PlacedTiles);
    }

    public void Respawn() {
        transform.position = tileSelection.CellToWorld(startingPosition);
        playerPosition = startingPosition;
        if(turnTracker.QueryTurn() == this && initialised){
            turnTracker.CycleThroughTurn();
            Debug.Log("You killed" + nameTag);
        }
        else if(!initialised) {
            return;
        }
        else {
            Debug.Log("You died");
        }
    }
}
