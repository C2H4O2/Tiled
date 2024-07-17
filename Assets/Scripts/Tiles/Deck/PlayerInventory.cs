using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private DeckGenerator deckGenerator;
    [SerializeField] private List<EffectTile> inventory = new List<EffectTile>();

    public List<EffectTile> Inventory { get => inventory; set => inventory = value; }

    private void Awake() {
        deckGenerator = FindAnyObjectByType<DeckGenerator>();
    }

    private void Start() {
        for (int i = 0; i < 6; i++) {
            inventory.Add(deckGenerator.PickRandomTile().GetComponent<EffectTile>());
        }
    }

    public void RemoveTile(EffectTile tileToRemove) {
        var tile = inventory.FirstOrDefault(t => t.name == tileToRemove.name);
        if (tile != null) {
            inventory.Remove(tile);
        }
    }

    public void DrawTile() {
        inventory.Add(deckGenerator.PickRandomTile().GetComponent<EffectTile>());
    }

    public void ReplaceTile(EffectTile tileToRemove, EffectTile tileToAdd) {
        var index = inventory.FindIndex(t => t.name == tileToRemove.name);
        if (index != -1) {
            inventory[index] = tileToAdd;
        }
    }
}
