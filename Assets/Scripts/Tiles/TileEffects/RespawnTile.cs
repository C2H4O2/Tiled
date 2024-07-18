using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTile : EffectTile
{
    public override void OnLand(Vector2Int landedPosition)
    {
        Debug.Log("Respawn");
    }
}
