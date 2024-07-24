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
        List<EffectTileInfo> tempList = new List<EffectTileInfo>();
        foreach (EffectTileInfo effectTileInfo in effectTilePosition.Values)
        {
            tempList.Add(effectTileInfo);
        }

        // Shuffle the list using Fisher-Yates algorithm
        for (int i = 0; i < tempList.Count; i++)
        {
            int rng = Random.Range(0, tempList.Count);
            EffectTileInfo temp = tempList[i];
            tempList[i] = tempList[rng];
            tempList[rng] = temp;
        }

        // Update the dictionary with new scrambled values
        List<Vector2Int> keys = new List<Vector2Int>(effectTilePosition.Keys);
        for (int i = 0; i < keys.Count; i++)
        {
            effectTilePosition[keys[i]] = tempList[i];
        }
        
    }
}