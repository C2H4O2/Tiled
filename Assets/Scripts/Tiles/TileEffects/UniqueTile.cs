using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueTile : EffectTile
{
    public override void OnLand(Vector2Int tilePosition)
    {
        Debug.Log("Landed on " + this.gameObject.name);
    }

}
