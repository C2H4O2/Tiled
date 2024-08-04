using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightBulbTile : EffectTile
{
    [SerializeField] private Tile lightOnTile;
    [SerializeField] private Tile lightOffTile;

    public Tile LightOnTile { get => lightOnTile; }
    public Tile LightOffTile { get => lightOffTile; }


    public override void OnLand(Vector2Int landedPosition)
    {
        TileSelection tileSelection = FindAnyObjectByType<TileSelection>();
        LightController lightController = FindAnyObjectByType<LightController>();
        EffectTilePositions effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        
        lightController.ToggleGlobalLight();
        
        TileToPlace = lightController.GlobalLightEnabled() ? LightOnTile : LightOffTile;
        
        if (effectTilePositions.TryGetAllEffectPositionsOfType(GetComponent<LightBulbTile>(), out var lightBulbPositions))
        {
            foreach (var lightBulbPosition in lightBulbPositions)
            {
                tileSelection.PlacedTiles.SetTile((Vector3Int)lightBulbPosition, TileToPlace);
            }
        }
    }
}
