using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DotController : MonoBehaviour, IPointerClickHandler
{
    public LineController _line = default;
    public int index = default;
    public Action<DotController> OnRightClickEvent = default;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerId == -2)
        {
            OnRightClickEvent?.Invoke(this);
        }
    }

    public void SetLine(LineController line)
    {
        this._line = line;
    }
}
