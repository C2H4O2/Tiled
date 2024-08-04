using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraMoveTile : EffectTile
{
    public override void OnLand(Vector2Int tilePosition) {
        TurnTracker turnTracker = FindAnyObjectByType<TurnTracker>();
        turnTracker.MovesLeft += 1;
    }

}
