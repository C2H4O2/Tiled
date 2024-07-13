using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTiles : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private bool draggingTile = false;
    private Vector2 defaultPosition;
    private Transform defaultParent;
    private Canvas canvas;

    public bool DraggingTile { get => draggingTile; }

    private void Start() {
        defaultPosition = transform.position;
        defaultParent = transform.parent;
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingTile = true;
        defaultPosition = transform.position;
        defaultParent = transform.parent;
       
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingTile = false;


        if (IsOutsideLayoutGroup())
        {   // Return the tile back to its original position and parent
            transform.position = defaultPosition;
            transform.SetParent(defaultParent);
        }
        else
        {   // If inside the layout group, reparent it to the default parent
            
            transform.SetParent(defaultParent);
        }
    }

    private bool IsOutsideLayoutGroup()
    {
        RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();

        Vector3[] worldCorners = new Vector3[4];
        GetComponent<RectTransform>().GetWorldCorners(worldCorners);

        foreach (var corner in worldCorners)
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(canvasRectTransform, corner, canvas.worldCamera))
            {
                return true;
            }
        }
        return false;
    }
}
