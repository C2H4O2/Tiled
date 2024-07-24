using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class DragTiles : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    
    private TurnTracker turnTracker;
    private TileSelection tileSelection;
    private NeighbourTileFinder neighbourTileFinder;
    private EffectTilePositions effectTilePositions;
    private PlaceTiles placeTiles;
    private Vector2 defaultPosition;

    private EffectTile effectTile;
    private DeckUIController deckUIController;

    private Transform defaultParent;
    private Canvas canvas;

    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        tileSelection = FindAnyObjectByType<TileSelection>();
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        placeTiles = FindAnyObjectByType<PlaceTiles>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        deckUIController = FindAnyObjectByType<DeckUIController>();
        canvas = FindAnyObjectByType<Canvas>();
        effectTile = GetComponent<EffectTile>();
        
    }
    private void Start() {
        defaultPosition = transform.position;
        defaultParent = transform.parent;
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        defaultPosition = transform.position;
        defaultParent = transform.parent;
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        turnTracker.DraggingTile = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (IsOutsideLayoutGroup())
        {   // Return the tile back to its original position and parent
            transform.position = defaultPosition;
            transform.SetParent(defaultParent);
        }
        else
        {   // If inside the layout group, reparent it to the default parent
            transform.SetParent(defaultParent);
        }
        if ((!tileSelection.PlacedTileAtPosition(tileSelection.HighlightedTilePosition)
        && tileSelection.BoardTile.HasTile((Vector3Int)tileSelection.HighlightedTilePosition))
        || neighbourTileFinder.FindAdjacentTiles(turnTracker.QueryTurn().PlayerPosition, tileSelection.BoardTile).Contains(tileSelection.HighlightedTilePosition))
        {
            
            if(effectTilePositions.TryGetEffectTile(tileSelection.HighlightedTilePosition, out var effectTileInfo)) {
                effectTileInfo.EffectTile.OnRemoval();
                if (effectTileInfo.EffectTile.IsIrreplaceable)
                    return;   
            }
            Debug.Log("place tile");
            
            placeTiles.PlaceTile(effectTile,tileSelection.HighlightedTilePosition, true);
            turnTracker.QueryTurn().PlayerInventory.RemoveTile(effectTile);
            turnTracker.QueryTurn().PlayerInventory.DrawTile();
            deckUIController.DisplayDeck();
            turnTracker.MovesLeft-=1;
            turnTracker.QueryTurn().UpdateAdjacentTiles();
        }

      
        turnTracker.TriggerDragDelay();
       
    }
    

    private bool IsOutsideLayoutGroup()
    {
        RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();

        Vector3[] worldCorners = new Vector3[4];
        GetComponent<RectTransform>().GetWorldCorners(worldCorners);

        foreach (var corner in worldCorners)
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(canvasRectTransform, corner, canvas.worldCamera))
            {
                return true;
            }
        }
        return false;
    }
}
