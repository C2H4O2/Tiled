using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueTile : EffectTile
{
    public override void OnLand()
    {
        Debug.Log("Landed on " + this.gameObject.name);
    }

}
