using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPadController : MonoBehaviour, IPointerDownHandler,IPointerUpHandler,IDragHandler {

    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smothingDirection;

    public float smothing;

    private void Awake()
    {
        direction = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        origin = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector2 currentPosition = eventData.position;
        Vector2 directionRaw = currentPosition - origin;
        direction = directionRaw.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        direction = Vector2.zero;
    }

    public Vector2 GetPosition()
    {
        smothingDirection = Vector2.MoveTowards(smothingDirection, direction, smothing);
        Debug.Log("GetPosition" + smothingDirection.x);
        return smothingDirection;
    }
}
