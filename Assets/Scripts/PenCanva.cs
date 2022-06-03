using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PenCanva : MonoBehaviour, IPointerClickHandler
{
    public Action OnPenCanvasLeftClickEvent = default;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerId == -1)
        {
            OnPenCanvasLeftClickEvent?.Invoke();
        }
    }
}
