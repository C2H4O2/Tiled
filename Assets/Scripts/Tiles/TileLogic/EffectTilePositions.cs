using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTilePositions : MonoBehaviour
{
    [System.Serializable]
    public class EffectTileInfo
    {
        public EffectTile EffectTile { get; set; }
        public bool IsFacingPositive { get; set; }

        public EffectTileInfo(EffectTile effectTile, bool isFacingPositive)
        {
            EffectTile = effectTile;
            IsFacingPositive = isFacingPositive;
        }
    }

    [SerializeField] private Dictionary<Vector2Int, EffectTileInfo> effectTilePosition = new Dictionary<Vector2Int, EffectTileInfo>();

    public Dictionary<Vector2Int, EffectTileInfo> EffectTilePosition { get => effectTilePosition; set => effectTilePosition = value; }

    public void AddEffectTile(Vector2Int position, EffectTile effectTile, bool isFacingPositive)
    {
        EffectTileInfo effectTileInfo = new EffectTileInfo(effectTile, isFacingPositive);
        effectTilePosition[position] = effectTileInfo;

        // Debugging statement to confirm the tile was added
        Debug.Log($"EffectTile added at position {position} with IsFacingPositive: {isFacingPositive}");
    }

    public bool TryGetEffectTile(Vector2Int position, out EffectTileInfo effectTileInfo)
    {
        if (effectTilePosition.TryGetValue(position, out effectTileInfo))
        {
            return true;
        }

        // Debugging statement if the tile was not found
        Debug.LogWarning($"No EffectTile found at position {position}");
        effectTileInfo = null;
        return false;
    }
}
