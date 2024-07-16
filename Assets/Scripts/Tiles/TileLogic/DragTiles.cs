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
    private PlaceTiles placeTiles;
    private Vector2 defaultPosition;

    private EffectTile effectTile;

    private Transform defaultParent;
    private Canvas canvas;

    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        tileSelection = FindAnyObjectByType<TileSelection>();
        placeTiles = FindAnyObjectByType<PlaceTiles>();
        canvas = GetComponentInParent<Canvas>();
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
        if (!tileSelection.PlacedTileAtPosition(tileSelection.HighlightedTilePosition)
        && tileSelection.BoardTile.HasTile((Vector3Int)tileSelection.HighlightedTilePosition))
        {
            Debug.Log("place tile");
            placeTiles.PlaceTile(effectTile,tileSelection.HighlightedTilePosition);
            turnTracker.MovesLeft-=1;
            turnTracker.QueryTurn().UpdateAdjacentTiles();
        }
        if (IsOutsideLayoutGroup())
        {   // Return the tile back to its original position and parent
            transform.position = defaultPosition;
            transform.SetParent(defaultParent);
        }
        else
        {   // If inside the layout group, reparent it to the default parent
            
            transform.SetParent(defaultParent);
        }
        StartCoroutine(DelayThenUpdateDraggingTile(0.2f));
       
    }
    private IEnumerator DelayThenUpdateDraggingTile(float seconds) {
        yield return new WaitForSeconds(seconds);
        turnTracker.DraggingTile = false;
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
