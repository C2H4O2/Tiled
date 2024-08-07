using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTilePositions : MonoBehaviour
{
    [SerializeField] private Player[] players;
    [SerializeField] private Vector2Int[] playerPositions;
    [SerializeField] private Vector2Int[] startingPositions;

    public Vector2Int[] PlayerPositions { get => playerPositions; }
    public Vector2Int[] StartingPositions { get => startingPositions; }

    private void Awake() {
        players = FindObjectsOfType<Player>();
    }

    private void Start() {
        playerPositions = new Vector2Int[players.Length];
        startingPositions = new Vector2Int[players.Length]; 

        for (int i = 0; i < players.Length; i++) {
            startingPositions[i] = players[i].StartingPosition;
        }
    }

    public void UpdateAllPlayerTilePositions() {
        for (int i = 0; i < players.Length; i++) {
            playerPositions[i] = players[i].PlayerPosition;
            players[i].UpdateAdjacentTiles();
        }
        
    }

    public Player GetPlayerAtTilePosition(Vector2Int tilePosition) {
        int i = Array.IndexOf(playerPositions, tilePosition);
        if (i >= 0 && i < players.Length) {
            return players[i];
        }
        return null;
    }
}
