using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WinDisplayer : MonoBehaviour
{
    private TurnTracker turnTracker;
    public UnityEvent BlueHasWon;
    public UnityEvent RedHasWon;
    public void Win(Player player) {
        if(turnTracker.TeamOnePlayers.Contains(player)) {
            BlueHasWon.Invoke();
        }
        else {
            RedHasWon.Invoke();
        }
    }
}
