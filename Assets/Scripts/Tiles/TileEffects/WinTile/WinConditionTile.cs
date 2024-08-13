using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class WinConditionTile : EffectTile
{
    
    public override void OnLand(Vector2Int landedPosition)
    {
        WinDisplayer winDisplayer = FindAnyObjectByType<WinDisplayer>();
        PlayerTilePositions playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        TurnTracker turnTracker = FindAnyObjectByType<TurnTracker>();
        EffectTilePositions effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        Player player = playerTilePositions.GetPlayerAtTilePosition(landedPosition);
        if(effectTilePositions.TryGetEffectTile(landedPosition, out var effectTileInfo)){
            if(turnTracker.TeamOnePlayers.Contains(player) && !effectTileInfo.IsFacingPositive)
            {
                Debug.Log("Team One Wins");
                winDisplayer.Win(player);
            }
            else if(turnTracker.TeamTwoPlayers.Contains(player) && effectTileInfo.IsFacingPositive)
            {
                Debug.Log("Team Two wins");
                winDisplayer.Win(player);
            }
            else
            {
                player.Respawn();
                Debug.Log("Campers Die");
            }
        }
        //make an event ping to open ui
    }
}
