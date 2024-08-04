using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TurnTracker : MonoBehaviour
{
    [SerializeField] private Player[] teamOnePlayers;
    [SerializeField] private Player[] teamTwoPlayers;
    [SerializeField] private Player[] turnOrder;
    private ushort turn = 0;
    private Player currentPlayerTurn;
    private int movesLeft;
    [SerializeField] private UnityEvent onTurnChange; //change camera
    private bool draggingTile;

    public UnityEvent OnTurnChange { get => onTurnChange; }
    public int MovesLeft { get => movesLeft; set => movesLeft = value; }
    public bool DraggingTile { get => draggingTile; set => draggingTile = value; }
    public Player[] TeamOnePlayers { get => teamOnePlayers; }
    public Player[] TeamTwoPlayers { get => teamTwoPlayers; }

    private void OnEnable() {
        InitializeTurnOrder();
        RandomiseTurn();
        
        currentPlayerTurn = turnOrder[0];
        movesLeft = PityDiceRoll();
    }
    private void Start() {
        OnTurnChange.Invoke();
        
    }
    
    public void TriggerDragDelay() {
        StartCoroutine(DelayThenUpdateDraggingTile(0.2f));
    }
    private IEnumerator DelayThenUpdateDraggingTile(float seconds) {
        yield return new WaitForSeconds(seconds);
        DraggingTile = false;
    }
    public Player QueryTurn()
    {
        return currentPlayerTurn;
    }

    public int RollDice(int sides)
    {
        int roll = Random.Range(1, sides+1);
        return Mathf.Max(roll, 3);
    }
    
    public int RollNDice(int sides, int numberOfRolls)
    {
        int sum = 0;
        for (int i = 0; i < numberOfRolls; i++)
        {
            sum += RollDice(sides);
        }
        return sum;
    }
    
    public int PityDiceRoll() {
        int roll = Random.Range(1, 7);
        if(roll < 3) {
            roll += Random.Range(1, 7);
        }
        return roll;
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
        movesLeft = PityDiceRoll();
        //movesLeft = RollDice(6);
        currentPlayerTurn.PlayerInventory.ReDrawDeck();
        
        OnTurnChange.Invoke();
    }
    
}
