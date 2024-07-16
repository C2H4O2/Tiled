using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class EffectTile : MonoBehaviour
{
    [SerializeField] private Tile tileToPlace;
    public Tile TileToPlace { get => tileToPlace; }
    public abstract void OnLand();

}
