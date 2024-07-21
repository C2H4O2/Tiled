using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class EffectTile : MonoBehaviour
{
    [SerializeField] private Tile tileToPlace;
    [SerializeField] private int id;
    [SerializeField] private bool isDirectional;
    [SerializeField] private bool isIndestructable;
    [SerializeField][TextArea] private string description;

    public int ID { get => id; set => id = value; }
    public bool IsDirectional { get => isDirectional; }
    public bool IsIndestructable { get => isIndestructable; }
    public Tile TileToPlace { get => tileToPlace; set => tileToPlace = value; }

    public abstract void OnLand(Vector2Int landedPosition);
    

}
