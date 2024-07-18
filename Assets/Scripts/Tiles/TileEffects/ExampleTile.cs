using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ExampleTile : EffectTile
{
    TurnTracker turnTracker;
    public override void OnLand(Vector2Int tilePosition)
    {
        Debug.Log("Landed");
    }
}
