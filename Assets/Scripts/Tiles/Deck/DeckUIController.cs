using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckUIController : MonoBehaviour
{
    private TurnTracker turnTracker;
    [SerializeField] private GameObject tileHolder;
    
    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }

    public void DisplayDeck() {
        DestroyChildren(tileHolder);
        List<EffectTile> inventory = turnTracker.QueryTurn().PlayerInventory.Inventory;
        List<GameObject> inventoryGameObjects = new List<GameObject>();
        foreach (EffectTile effectTile in inventory) {
            inventoryGameObjects.Add(effectTile.gameObject);
        }
        foreach (GameObject gameObject in inventoryGameObjects) {
            GameObject tileInstance = Instantiate(gameObject);
            tileInstance.transform.SetParent(tileHolder.transform);
            tileInstance.transform.localScale = Vector3.one;
            tileInstance.transform.localPosition = Vector3.zero;
        }
        
    }

    private void DestroyChildren(GameObject parent) {
        foreach (Transform child in parent.transform) {
            Destroy(child.gameObject);
        }
    }
}
