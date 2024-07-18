using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class EffectTile : MonoBehaviour
{
    [SerializeField] private Tile tileToPlace;
    [SerializeField] private int id;
    public Tile TileToPlace { get => tileToPlace; }
    public int ID { get => id; set => id = value; }
    public abstract void OnLand(Vector2Int landedPosition);
    

}
