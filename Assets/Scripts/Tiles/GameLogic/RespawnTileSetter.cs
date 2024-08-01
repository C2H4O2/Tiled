using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RespawnTileSetter : MonoBehaviour
{
    [SerializeField] private EffectTile blueRespawnTile;
    [SerializeField] private EffectTile redRespawnTile;

    [SerializeField] private List<Vector2Int> blueSpawnPositions = new List<Vector2Int>();
    [SerializeField] private List<Vector2Int> redSpawnPositions = new List<Vector2Int>();


    private PlaceTiles placeTiles;

    private void Awake()
    {
        placeTiles = FindAnyObjectByType<PlaceTiles>();
    }

    private void Start()
    {
        InitializeSpawnTiles();
    }

    private void InitializeSpawnTiles()
    {
        foreach (var position in blueSpawnPositions)
        {
            placeTiles.PlaceTile(blueRespawnTile, position, triggerEffect: false, initialise: true, isFacingPositive:true);
        }

        foreach (var position in redSpawnPositions)
        {
            placeTiles.PlaceTile(redRespawnTile, position, triggerEffect: false, initialise: true, isFacingPositive:false);
        }
    }
}
