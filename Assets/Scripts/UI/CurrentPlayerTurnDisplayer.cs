using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentPlayerTurnDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text currentPlayerTurnText;
    [SerializeField] private TurnTracker turnTracker;
    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }
    public void ChangeCurrentPlayerText()
    {
        currentPlayerTurnText.text = "Turn: " + turnTracker.QueryTurn().NameTag;
    }
}
