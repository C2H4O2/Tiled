using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTracker : MonoBehaviour
{
    [SerializeField] private Player[] teamOnePlayers;
    [SerializeField] private Player[] teamTwoPlayers;
    [SerializeField] private Player[] turnOrder;
    [SerializeField] private ushort turn = 0;
    [SerializeField] private Player currentPlayerTurn;

    private Player QueryTurn()
    {
        return currentPlayerTurn;
    }

    private int Roll6SidedDice()
    {
        return Random.Range(1, 7); // include 1 exclude 7
    }

    private void Start() {
        InitializeTurnOrder();
        RandomiseTurn();
        currentPlayerTurn = turnOrder[0]; // Set the initial player turn
    }
    
    private void InitializeTurnOrder() 
    {
        int totalPlayers = teamOnePlayers.Length + teamTwoPlayers.Length;
        turnOrder = new Player[totalPlayers];
    }

    private void RandomiseTurn() 
    {
        InitializeTurnOrder();

        if (Random.Range(1, 3) == 1) { //inclusive 1, exclude 3
            turnOrder[0] = teamOnePlayers[0];
            turnOrder[1] = teamTwoPlayers[0];
            turnOrder[2] = teamOnePlayers[1];
            turnOrder[3] = teamTwoPlayers[1];
        }
        else {
            turnOrder[0] = teamTwoPlayers[0];
            turnOrder[1] = teamOnePlayers[0];
            turnOrder[2] = teamTwoPlayers[1];
            turnOrder[3] = teamOnePlayers[1];
        }
    }

    public void CycleThroughTurn()
    {
        turn += 1;
        currentPlayerTurn = turnOrder[turn % turnOrder.Length];
    }
}
