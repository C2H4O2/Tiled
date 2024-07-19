using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTile : EffectTile
{
    private TurnTracker turnTracker;
    
    public override void OnLand(Vector2Int tilePosition) {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        turnTracker.CycleThroughTurn();
    }
}
