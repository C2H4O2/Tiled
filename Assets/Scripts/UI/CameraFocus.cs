using UnityEngine;
using Cinemachine;

public class CameraFocus : MonoBehaviour
{
    private TurnTracker turnTracker;
    [SerializeField] private Vector3 fixedPoint;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float lerpSpeed = 5f; // Adjust as needed

    private void Awake()
    {
        turnTracker = FindAnyObjectByType<TurnTracker>();
    }

    private void LateUpdate()
    {
        if (turnTracker.QueryTurn() != null)
        {
            Vector3 playerPosition = turnTracker.QueryTurn().transform.position;
            Vector3 midpoint = (playerPosition + fixedPoint) / 2;

            // Lerping the camera position
            Vector3 newPosition = Vector3.Lerp(virtualCamera.transform.position, midpoint, lerpSpeed * Time.deltaTime);
            virtualCamera.transform.position = new Vector3(newPosition.x, newPosition.y, virtualCamera.transform.position.z);
        }
    }
}
