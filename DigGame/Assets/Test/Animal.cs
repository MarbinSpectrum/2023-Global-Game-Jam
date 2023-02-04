using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Vector2 _offset, _originalPosition;
    private bool _dragging, _crashed, _clicked;
    private Sprite _changeSprite;


    private void Awake()
    {
        _originalPosition = transform.position;
        Debug.Log(this.name);
        _changeSprite = Resources.Load<Sprite>($"Animal/{this.name}");
    }

    void Update()
    {
        //if (!_dragging) return;
        //if (_placed) return;

        var mousePosition = GetMousePos();

        if (_clicked)
        {
            transform.position = mousePosition;
        }
    }

    void OnMouseDown()
    {
        //_dragging = true;
        _clicked = !_clicked;
        //_offset = GetMousePos() - (Vector2)transform.position;
    }

    void OnMouseUp()
    {
        _dragging = false;
        if (!_clicked && !_crashed)
        {
            this.GetComponent<SpriteRenderer>().sprite = _changeSprite;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _crashed = true;
        if (!_clicked)
        {
            transform.position = _originalPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _crashed = false;
    }

    Vector2 GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition; 
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2Int pos = new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y));
        return pos;
    }
}
