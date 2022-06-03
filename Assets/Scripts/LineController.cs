using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _lr = default;
    private List<DotController> _dots = default;

    private void Awake()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.positionCount = 0;
        _dots = new List<DotController>();
    }

    public void AddPoint(DotController dot)
    {
        dot.index = _dots.Count;
        dot.SetLine(this);
        _lr.positionCount++;
        _dots.Add(dot);
    }

    public void SplitPointsAtIndex(int index, out List<DotController> beforeDots, out List<DotController> afterDots)
    {
        List<DotController> before = new List<DotController>();
        List<DotController> after = new List<DotController>();

        int i = 0;
        for(; i < index; i++)
        {
            before.Add(_dots[i]);
        }
        i++;
        for(; i < _dots.Count; i++)
        {
            after.Add(_dots[i]);
        }

        beforeDots = before;
        afterDots = after;
    }

    private void LateUpdate()
    {
        if (_dots.Count >= 2)
        {
            for (int i = 0; i < _dots.Count; i++)
            {
                _lr.SetPosition(i, _dots[i].transform.position);
            }
        }
    }
}
