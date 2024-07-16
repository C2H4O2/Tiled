using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private TurnTracker turnTracker;
    [SerializeField] private CinemachineVirtualCamera vCamera;

    private void Awake() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }
    
    public void SwitchCameraTarget() 
    {
        Player player = turnTracker.QueryTurn();
        vCamera.Follow = player.gameObject.transform;
    }
}
