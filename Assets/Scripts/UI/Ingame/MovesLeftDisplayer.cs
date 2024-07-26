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
    private void Update() {
        ChangeMovesLeftText();
    }
    public void ChangeMovesLeftText()
    {
        movesLeftText.text = "Moves Left: " + turnTracker.MovesLeft;
    }
}
