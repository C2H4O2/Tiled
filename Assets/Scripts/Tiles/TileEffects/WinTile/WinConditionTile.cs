using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WinConditionTile : EffectTile
{
    private PlayerTilePositions playerTilePositions;
    private TurnTracker turnTracker;
    private EffectTilePositions effectTilePositions;
    [SerializeField] GameObject playAgainButton;
    
    public override void OnLand(Vector2Int landedPosition)
    {
        playerTilePositions = FindAnyObjectByType<PlayerTilePositions>();
        turnTracker = FindAnyObjectByType<TurnTracker>();
        effectTilePositions = FindAnyObjectByType<EffectTilePositions>();
        Player player = playerTilePositions.GetPlayerAtTilePosition(landedPosition);
        if(effectTilePositions.TryGetEffectTile(landedPosition, out var effectTileInfo)){
            if(turnTracker.TeamOnePlayers.Contains(player) && !effectTileInfo.IsFacingPositive)
            {
                Debug.Log("Team One Wins");
                playAgainButton.SetActive(true);
            }
            else if(turnTracker.TeamTwoPlayers.Contains(player) && effectTileInfo.IsFacingPositive)
            {
                Debug.Log("Team Two wins");
                playAgainButton.SetActive(true);
            }
            else
            {
                player.Respawn();
                Debug.Log("Campers Die");
            }
        }
    }
}
