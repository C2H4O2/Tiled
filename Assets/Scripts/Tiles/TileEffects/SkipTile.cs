using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTile : EffectTile
{
    public override void OnLand(Vector2Int tilePosition) {
        TurnTracker turnTracker = FindAnyObjectByType<TurnTracker>();
        turnTracker.CycleThroughTurn();
    }
}
