using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckGenerator : MonoBehaviour
{
    // Note: total tiles is 130
    [SerializeField] private GameObject[] commonTiles;
    [SerializeField] private GameObject[] rareTiles;
    [SerializeField] private GameObject[] epicTiles;
    [SerializeField] private GameObject[] legendaryTiles;
    [SerializeField] private GameObject[] uniqueTiles;

    [SerializeField] private GameObject[] allTiles;

    private Dictionary<int, GameObject> tileDictionary = new Dictionary<int, GameObject>();
    private void Awake() {
        allTiles = commonTiles.Concat(rareTiles)
                            .Concat(epicTiles)
                            .Concat(legendaryTiles)
                            .Concat(uniqueTiles)
                            .ToArray();

        // Assign unique IDs to each tile and populate the dictionary
        for (int i = 0; i < allTiles.Length; i++)
        {
            EffectTile effectTileComponent = allTiles[i].GetComponent<EffectTile>();
            if (effectTileComponent != null)
            {
                effectTileComponent.ID = i;
                tileDictionary.Add(i, allTiles[i]);
            }
        }
    }

    public GameObject PickRandomTile()
    {
        float random = Random.Range(0f, 1f);

        if (random < 0.5f) // 50% chance for common cards
        {
            return commonTiles[Random.Range(0, commonTiles.Length)];
        }
        else if (random < 0.8f) // 30% chance for rare cards
        {
            return rareTiles[Random.Range(0, rareTiles.Length)];
        }
        else if (random < 0.95f) // 15% chance for epic cards
        {
            return epicTiles[Random.Range(0, epicTiles.Length)];
        }
        else // 5% chance for legendary cards
        {
            return legendaryTiles[Random.Range(0, legendaryTiles.Length)];
        }
    }

    public GameObject GetTileByEffectTile(EffectTile effectTile)
    {
        if (effectTile != null && tileDictionary.ContainsKey(effectTile.ID))
        {
            return tileDictionary[effectTile.ID];
        }
        return null;
    }
}
