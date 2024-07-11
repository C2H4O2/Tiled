using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourTileFinder : MonoBehaviour
{
    private TileSelection tileSelection;
    private Vector2Int highlightedTilePosition;
    private Vector2Int[] adjacentTilePositions;

    private void Awake() {
        tileSelection = FindAnyObjectByType<TileSelection>();
    }

    private void Update() {
        highlightedTilePosition = tileSelection.HighlightedTilePosition;

        List<Vector2Int> neighbors = new List<Vector2Int>();

        if (highlightedTilePosition.y % 2 == 1) {
            neighbors.Add(new Vector2Int(highlightedTilePosition.x, highlightedTilePosition.y + 1));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x + 1, highlightedTilePosition.y + 1));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x - 1, highlightedTilePosition.y));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x + 1, highlightedTilePosition.y));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x, highlightedTilePosition.y - 1));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x + 1, highlightedTilePosition.y - 1));
        } else {
            neighbors.Add(new Vector2Int(highlightedTilePosition.x, highlightedTilePosition.y + 1));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x - 1, highlightedTilePosition.y + 1));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x - 1, highlightedTilePosition.y));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x + 1, highlightedTilePosition.y));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x, highlightedTilePosition.y - 1));
            neighbors.Add(new Vector2Int(highlightedTilePosition.x - 1, highlightedTilePosition.y - 1));
        }

        adjacentTilePositions = neighbors.ToArray();
    }

    public Vector2Int[] GetAdjacentTilePositions()
    {
        return adjacentTilePositions;
    }
}
