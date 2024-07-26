using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileExistsDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text coordinateTextField;
    private TileSelection tileSelection;
    [SerializeField] private Tilemap placedTiles;
    private void Awake() {
        tileSelection = FindAnyObjectByType<TileSelection>();
    }

    private void Update() {
        if(placedTiles.HasTile((Vector3Int)tileSelection.HighlightedTilePosition)) {
            coordinateTextField.color=Color.green;
        }
        else {
            coordinateTextField.color=Color.red;
        }
        
    }
}
