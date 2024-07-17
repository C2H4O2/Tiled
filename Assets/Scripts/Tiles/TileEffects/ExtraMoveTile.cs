using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraMoveTile : EffectTile
{
    [SerializeField] private TurnTracker turnTracker;
    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }
    public override void OnLand() {
        turnTracker.MovesLeft += 1;
    }
}
