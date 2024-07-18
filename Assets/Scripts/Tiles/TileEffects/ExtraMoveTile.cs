using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraMoveTile : EffectTile
{
    private TurnTracker turnTracker;
    
    public override void OnLand(Vector2Int tilePosition) {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        turnTracker.MovesLeft += 1;
    }

}
