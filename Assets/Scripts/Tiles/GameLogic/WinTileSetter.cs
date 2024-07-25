using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTileSetter : MonoBehaviour
{
    [SerializeField] private Vector2Int blueBasePos;
    [SerializeField] private Vector2Int redBasePos;
    [SerializeField] private GameObject winConditionTilePrefab;
    private PlaceTiles placeTiles;
    
    private void Awake() {
        placeTiles = FindAnyObjectByType<PlaceTiles>();
    }
    private void Start() {
        EffectTile WinEffectTile = winConditionTilePrefab.GetComponent<WinConditionTile>();
        placeTiles.InitialiseTile(WinEffectTile, blueBasePos, true);
        placeTiles.InitialiseTile(WinEffectTile, redBasePos, false);
    }
}
