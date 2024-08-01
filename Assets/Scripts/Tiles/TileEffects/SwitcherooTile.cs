using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwitcherooTile : EffectTile
{
    private TurnTracker turnTracker;
    private PlayerTilePositions playerTilePositions;
    public override void OnLand(Vector2Int landedPosition)
    {
        turnTracker = FindAnyObjectByType<TurnTracker>();
        playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        Player player = playerTilePositions.GetPlayerAtTilePosition(landedPosition);
        if(turnTracker.TeamOnePlayers.Contains(player)) {
            Player[] teamPlayers = turnTracker.TeamOnePlayers;
            switchPositions(teamPlayers);
        }
        if(turnTracker.TeamTwoPlayers.Contains(player)) {
            Player[] teamPlayers = turnTracker.TeamTwoPlayers;
            switchPositions(teamPlayers);
        }

        
    }

    private void switchPositions(Player[] teamPlayers) {
            Vector2Int tempPos = teamPlayers[0].PlayerPosition;
            teamPlayers[0].MovePlayerWithoutTriggeringEffect(teamPlayers[1].PlayerPosition, 0f);
            teamPlayers[1].MovePlayerWithoutTriggeringEffect(tempPos, 0f);
            playerTilePositions.UpdateAllPlayerTilePositions();
        }

}
