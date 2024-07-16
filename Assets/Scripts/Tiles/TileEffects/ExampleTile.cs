using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ExampleTile : EffectTile
{
    [SerializeField] private Tile tileToPlace;

    public override void OnLand()
    {
        throw new System.NotImplementedException();
    }
}
