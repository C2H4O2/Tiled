using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class WinConditionTile : EffectTile
{
    private PlayerTilePositions playerTilePositions;
    private TurnTracker turnTracker;
    private EffectTilePositions effectTilePositions;
    [SerializeField] private Button playAgainButton;
    
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
                playAgainButton.gameObject.SetActive(true);
            }
            else if(turnTracker.TeamTwoPlayers.Contains(player) && effectTileInfo.IsFacingPositive)
            {
                Debug.Log("Team Two wins");
                playAgainButton.gameObject.SetActive(true);
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
