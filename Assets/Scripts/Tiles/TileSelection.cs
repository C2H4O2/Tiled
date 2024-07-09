using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelection : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    private Vector2Int highlightedTilePosition = Vector2Int.zero;

    private void Update() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0; // Ensure Z-axis is zero for 2D calculations

        Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);
        highlightedTilePosition = new Vector2Int(cellPos.x, cellPos.y);

        Vector3 worldPos = tilemap.CellToWorld(cellPos);
        transform.position = worldPos;
    }

    public Vector2Int HighlightedTilePosition
    {
        get { return highlightedTilePosition; }
    }

    public bool IsHighlightedTileClicked(Vector2 clickedPosition)
    {
        Vector3Int cellPos = tilemap.WorldToCell(clickedPosition);
        Vector2Int gridPos = new Vector2Int(cellPos.x, cellPos.y);
        return gridPos == highlightedTilePosition;
    }

    public Vector2 GetHighlightedTilePosition()
    {
        Vector3 worldPos = tilemap.CellToWorld(new Vector3Int(highlightedTilePosition.x, highlightedTilePosition.y, 0));
        return new Vector2(worldPos.x, worldPos.y);
    }
}
