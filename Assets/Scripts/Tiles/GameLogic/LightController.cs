using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light2D globalLight;
    [SerializeField] private Light2D playerLight;
    [SerializeField] private GameObject lightBulbTile;
    private TurnTracker turnTracker;

    private void Awake()
    {
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }

    public void ToggleGlobalLight()
    {
        globalLight.enabled = !globalLight.enabled;
        
        LightBulbTile lightBulbComponent = lightBulbTile.GetComponent<LightBulbTile>();
        
        if (lightBulbComponent != null)
        {
            lightBulbComponent.TileToPlace = globalLight.enabled ? lightBulbComponent.LightOnTile : lightBulbComponent.LightOffTile;
        }
    }

    public bool GlobalLightEnabled()
    {
        return globalLight.enabled;
    }

    public void SwitchPlayerLightTarget()
    {
        playerLight.transform.parent = turnTracker.QueryTurn().transform;
        playerLight.transform.localPosition = Vector3.zero;
    }
}
