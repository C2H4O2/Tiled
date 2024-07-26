using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CoordinateDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text coordinateTextField;
    private TileSelection tileSelection;
    private void Awake() {
        tileSelection = FindAnyObjectByType<TileSelection>();
    }
    private void Update() {
        coordinateTextField.text = "Current tile coordinate:\n" + tileSelection.HighlightedTilePosition.x.ToString() + ", " + tileSelection.HighlightedTilePosition.y.ToString();

    }
}
