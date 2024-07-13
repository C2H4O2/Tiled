using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDeck : MonoBehaviour
{
    [SerializeField] private GameObject[] baseTiles;
    [SerializeField] private GameObject[] tiles;
    private void Start() {
        ShuffleTiles(baseTiles);
        ShuffleTiles(tiles);
    }

    private GameObject[] ShuffleTiles(GameObject[] tileArray) {
        for (int i = 0; i < tileArray.Length; i++)
        {
            GameObject temp = tileArray[i];
            int r = Random.Range(0, tileArray.Length);
            tileArray[i] = tileArray[r];
            tileArray[r] = temp;
        }
        return tileArray;
    }
}
