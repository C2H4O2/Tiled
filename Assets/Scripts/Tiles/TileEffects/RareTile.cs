using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareTile : EffectTile
{
    public override void OnLand()
    {
        Debug.Log("Landed on " + this.gameObject.name);
    }

    
}

