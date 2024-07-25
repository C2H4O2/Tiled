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

    public bool TryGetAllEffectPositionsOfType(EffectTile effectTile, out List<Vector2Int> positions)
    {
        positions = new List<Vector2Int>();

        foreach (var entry in effectTilePosition)
        {
            if (entry.Value.EffectTile == effectTile)
            {
                positions.Add(entry.Key);
            }
        }

        return positions.Count > 0;
    }

    public void ScrambleEffectTiles()
    {
        List<Vector2Int> destructibleKeys = new List<Vector2Int>();
        List<EffectTileInfo> destructibleTiles = new List<EffectTileInfo>();

        // Collect destructible tiles and their positions
        foreach (var kvp in effectTilePosition)
        {
            if (!kvp.Value.EffectTile.IsIndestructable)
            {
                destructibleKeys.Add(kvp.Key);
                destructibleTiles.Add(kvp.Value);
            }
        }

        // Shuffle the destructible tiles using Fisher-Yates algorithm
        for (int i = 0; i < destructibleTiles.Count; i++)
        {
            int rng = Random.Range(0, destructibleTiles.Count);
            EffectTileInfo temp = destructibleTiles[i];
            destructibleTiles[i] = destructibleTiles[rng];
            destructibleTiles[rng] = temp;
        }

        // Update the dictionary with new scrambled values for destructible tiles
        for (int i = 0; i < destructibleKeys.Count; i++)
        {
            effectTilePosition[destructibleKeys[i]] = destructibleTiles[i];
        }
    }

}