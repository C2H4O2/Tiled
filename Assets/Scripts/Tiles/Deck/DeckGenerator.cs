using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckGenerator : MonoBehaviour
{
    // Note: total tiles is 130
    [SerializeField] private GameObject[] commonTiles;
    [SerializeField] private GameObject[] rareTiles;
    [SerializeField] private GameObject[] epicTiles;
    [SerializeField] private GameObject[] legendaryTiles;
    [SerializeField] private GameObject[] UniqueTiles;

    public GameObject PickRandomTile() {
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
}
