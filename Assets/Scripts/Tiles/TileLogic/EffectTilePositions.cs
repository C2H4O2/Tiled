using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTilePositions : MonoBehaviour
{
    [SerializeField] private Dictionary<Vector2Int, EffectTile> effectTilePosition = new Dictionary<Vector2Int, EffectTile>();

    public Dictionary<Vector2Int, EffectTile> EffectTilePosition { get => effectTilePosition; set => effectTilePosition = value; }
}
