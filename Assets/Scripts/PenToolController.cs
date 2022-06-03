using System.Collections.Generic;
using UnityEngine;

public class PenToolController : MonoBehaviour
{
    [Header("Pen Canvas")]
    public PenCanva _penCanva = default;

    [Header("Dots")]
    public GameObject _dotPrefab = default; 
    public Transform _dotParent = default;

    [Header("Lines")]
    public Transform _lineParent = default;
    public GameObject _linePrefab = default;
    private LineController _currentLine = default;

    private void Start()
    {
        _penCanva.OnPenCanvasLeftClickEvent += AddDot;
    }

    private void AddDot()
    {
        if (_currentLine == null)
        {
            _currentLine = Instantiate(_linePrefab, Vector3.zero, Quaternion.identity, _lineParent).GetComponent<LineController>();
        }

        DotController dot = Instantiate(_dotPrefab, GetMousePosition(), Quaternion.identity, _dotParent).GetComponent<DotController>();
        dot.OnRightClickEvent += RemoveDot;
        _currentLine.AddPoint(dot);
    }

    private void RemoveDot(DotController dot)
    {
        LineController line = dot._line;
        line.SplitPointsAtIndex(dot.index, out List<DotController> before, out List<DotController> after);

        Destroy(line.gameObject);
        Destroy(dot.gameObject);

        LineController beforeLine = Instantiate(_linePrefab, Vector3.zero, Quaternion.identity, _lineParent).GetComponent<LineController>();
        for(int i = 0; i < before.Count; i++)
        {
            beforeLine.AddPoint(before[i]);
        }

        LineController afterLine = Instantiate(_linePrefab, Vector3.zero, Quaternion.identity, _lineParent).GetComponent<LineController>();
        for (int i = 0; i < after.Count; i++)
        {
            afterLine.AddPoint(after[i]);
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldMousePosition.z = 0;

        return worldMousePosition;
    }
}
