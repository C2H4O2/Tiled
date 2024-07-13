using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TurnTracker : MonoBehaviour
{
    [SerializeField] private Player[] teamOnePlayers;
    [SerializeField] private Player[] teamTwoPlayers;
    [SerializeField] private Player[] turnOrder;
    [SerializeField] private ushort turn = 0;
    [SerializeField] private Player currentPlayerTurn;
    [SerializeField] private UnityEvent onTurnChange; //change camera

    public UnityEvent OnTurnChange { get => onTurnChange; }


    public Player QueryTurn()
    {
        return currentPlayerTurn;
    }

    public int RollDice(int sides)
    {
        return Random.Range(1, sides+1); // include 1 exclude 7
    }

    private void Start() {
        InitializeTurnOrder();
        RandomiseTurn();
        
        currentPlayerTurn = turnOrder[0]; // Set the initial player turn
        OnTurnChange.Invoke();
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
        OnTurnChange.Invoke();
    }
}