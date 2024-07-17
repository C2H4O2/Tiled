using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegendaryTile : EffectTile
{
    public override void OnLand()
    {
        Debug.Log("Landed on " + this.gameObject.name);
    }

}
