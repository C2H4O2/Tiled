using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdjacentCoordinateDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text coordinateTextField;
    private NeighbourTileFinder neighbourTileFinder;
    private TileSelection tileSelection;

    private void Awake() {
        neighbourTileFinder = FindAnyObjectByType<NeighbourTileFinder>();
        tileSelection = FindAnyObjectByType<TileSelection>();
    }

    private void Update() {
      
        Vector2Int[] adjacentTiles = neighbourTileFinder.FindAdjacentTiles(tileSelection.HighlightedTilePosition, tileSelection.BoardTile);

        string coordinatesText = $"Adjacent Tiles:\n";
        foreach (Vector2Int tile in adjacentTiles) {
            coordinatesText += $"{tile.x}, {tile.y}\n";
        }

        coordinateTextField.text = coordinatesText;
    }
}
