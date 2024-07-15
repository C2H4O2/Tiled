using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTilePositions : MonoBehaviour
{
    [SerializeField] private Player[] players;
    [SerializeField] private Vector2Int[] playerPositions;

    public Vector2Int[] PlayerPositions { get => playerPositions; }

    private void Awake() {
        players = FindObjectsOfType<Player>();
        playerPositions = new Vector2Int[players.Length];
    }

    public void UpdateAllPlayerTilePositions() {
        for (int i = 0; i < players.Length; i++) {
            playerPositions[i] = players[i].PlayerPosition;
        }
    }
}
