using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class EffectTile : MonoBehaviour
{
    [SerializeField] private Tile tileToPlace;
    [SerializeField] private Tile blueTile;
    [SerializeField] private Tile redTile;
    [SerializeField] private int id;
    [SerializeField] private bool isDirectional;
    [SerializeField] private bool isIndestructable;
    [SerializeField] private bool isIrreplaceable;
    
    [SerializeField][TextArea] private string description;
    

    public int ID { get => id; set => id = value; }
    public bool IsDirectional { get => isDirectional; }
    public bool IsIndestructable { get => isIndestructable; }
    public Tile TileToPlace { get => tileToPlace; set => tileToPlace = value; }
    public bool IsIrreplaceable { get => isIrreplaceable; }
    public Tile BlueTile { get => blueTile; }
    public Tile RedTile { get => redTile; }

    public abstract void OnLand(Vector2Int landedPosition);
    
    public virtual void OnRemoval() { }
}
