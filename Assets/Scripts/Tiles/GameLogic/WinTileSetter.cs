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
        placeTiles.PlaceTile(WinEffectTile, blueBasePos, initialise:true, isFacingPositive:true);
        placeTiles.PlaceTile(WinEffectTile, redBasePos, initialise:true, isFacingPositive:false);
    }
}
