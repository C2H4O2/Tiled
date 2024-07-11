using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private TurnTracker turnTracker;
    private void Start() {
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }
    [SerializeField] private CinemachineVirtualCamera vCamera;
    public void SwitchCameraTarget() 
    {
        Player player = turnTracker.QueryTurn();
        vCamera.Follow = player.gameObject.transform;
    }
}
