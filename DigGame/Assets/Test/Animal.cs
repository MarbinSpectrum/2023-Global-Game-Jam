using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

    private Vector2 _offset, _originalPosition;
    private bool _dragging, _placed;


    private void Awake()
    {
        _originalPosition = transform.position;
    }

    void Update()
    {
        if (!_dragging) return;
        if (_placed) return;

        var mousePosition = GetMousePos();

        transform.position = mousePosition - _offset;
    }

    void OnMouseDown()
    {
        _dragging = true;
        _offset = GetMousePos() - (Vector2)transform.position;
    }

    void OnMouseUp()
    {
        _dragging = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Input.GetMouseButton(0))
        {
            transform.position = _originalPosition;
            _dragging = false;
        }
    }

    Vector2 GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2Int pos = new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y));
        Debug.Log(pos);
        return pos;
    }
}
