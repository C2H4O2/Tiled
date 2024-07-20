using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NametagDisplayer : MonoBehaviour
{
    private TextMesh textMesh;
    //private TurnTracker turnTracker;
    private void Awake() {
        textMesh = GetComponent<TextMesh>();
        //turnTracker = FindAnyObjectByType<TurnTracker>();
    }
    void Start()
    {
        EnableNametag();
    }
    private void EnableNametag() {
        textMesh.text = GetComponentInParent<Player>().NameTag;
    }
    
    /*
    public void ToggleNametags() {
        if(textMesh.text != null) {
            EnableNametag();
        }
        else {
            DisableNametag();
        }
    }
    
    private void DisableNametag() {
        textMesh.text = null;
    }

    public void ShowCurrentPlayerNametag() {
        if(GetComponent<Player>() == turnTracker.QueryTurn()) {
            EnableNametag();
        }
    }
    */
}
