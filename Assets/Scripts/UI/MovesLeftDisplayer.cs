using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesLeftDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text movesLeftText;
    private TurnTracker turnTracker;
    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }
    public void ChangeMovesLeftText()
    {
        Debug.Log(turnTracker.QueryTurn().MovesLeft);
        movesLeftText.text = "Moves Left: " + turnTracker.QueryTurn().MovesLeft;
    }
}
