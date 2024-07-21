using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightBulbTile : EffectTile
{
    private LightController lightController;
    private TileSelection tileSelection;
    private EffectTilePositions effectTilePositions;
    [SerializeField] private Tile lightOnTile;
    [SerializeField] private Tile lightOffTile;

    public Tile LightOnTile { get => lightOnTile; }
    public Tile LightOffTile { get => lightOffTile; }

    private Tile tileToPlace;

    public override void OnLand(Vector2Int landedPosition)
    {
        tileSelection = FindAnyObjectByType<TileSelection>();
        lightController = FindAnyObjectByType<LightController>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        
        lightController.ToggleGlobalLight();
        
        tileToPlace = lightController.GlobalLightEnabled() ? LightOnTile : LightOffTile;
        
        if (effectTilePositions.TryGetAllEffectPositionsOfType(GetComponent<LightBulbTile>(), out var lightBulbPositions))
        {
            foreach (var lightBulbPosition in lightBulbPositions)
            {
                tileSelection.PlacedTiles.SetTile((Vector3Int)lightBulbPosition, tileToPlace);
            }
        }
    }
}
