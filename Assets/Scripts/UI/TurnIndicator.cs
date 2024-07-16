using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIndicator : MonoBehaviour
{
    private TurnTracker turnTracker;
    [SerializeField] private GameObject indicatorArrow;

    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }

    public void MoveTurnIndicator() {
        //Debug.Log("moved");

        Transform currentPlayerTransform = turnTracker.QueryTurn().transform;
        indicatorArrow.transform.SetParent(currentPlayerTransform);

        SpriteRenderer spriteRenderer = currentPlayerTransform.GetComponent<SpriteRenderer>();
        float spriteHeight = spriteRenderer.bounds.size.y;

        indicatorArrow.transform.localPosition = new Vector3(0, spriteHeight + 1.5f, 0);
    }
}
