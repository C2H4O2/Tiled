using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelection : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    private Vector2Int highlightedTilePosition = Vector2Int.zero;
  

    public Vector2Int HighlightedTilePosition { get => highlightedTilePosition; }

    public Tilemap Tilemap { get => tilemap; }
    private void Update() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        Vector3Int cellPos = Tilemap.WorldToCell(mouseWorldPos);
        highlightedTilePosition = new Vector2Int(cellPos.x, cellPos.y);

        Vector3 worldPos = Tilemap.CellToWorld(cellPos);
        transform.position = worldPos;
    }

    public bool IsHighlightedTileClicked(Vector2 clickedPosition)
    {
        Vector3Int cellPos = Tilemap.WorldToCell(clickedPosition);
        Vector2Int gridPos = new Vector2Int(cellPos.x, cellPos.y);
        return gridPos == highlightedTilePosition;
    }

    public Vector2 GetHighlightedTilePosition()
    {
        Vector3 worldPos = Tilemap.CellToWorld(new Vector3Int(highlightedTilePosition.x, highlightedTilePosition.y, 0));
        return new Vector2(worldPos.x, worldPos.y);
    }


    public Vector2 CellToWorld(Vector2Int cellPosition)
    {    // Converts a cell position (in grid coordinates) to world position
        Vector3Int cellPos3D = new Vector3Int(cellPosition.x, cellPosition.y, 0);
        Vector3 worldPos3D = Tilemap.CellToWorld(cellPos3D);
        return new Vector2(worldPos3D.x, worldPos3D.y);
    }


    public Vector2Int WorldToCell(Vector2 worldPosition)
    {    // Converts a world position to cell position (in grid coordinates)
        Vector3 worldPos3D = new Vector3(worldPosition.x, worldPosition.y, 0);
        Vector3Int cellPos3D = Tilemap.WorldToCell(worldPos3D);
        return new Vector2Int(cellPos3D.x, cellPos3D.y);
    }
}
