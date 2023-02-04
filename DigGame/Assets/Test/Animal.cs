using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private Vector2 _offset, _originalPosition;
    private bool _dragging, _crashed;
    public bool _clicked = true;
    private Sprite _changeSprite;

    public enum AnimalType
    {
        Cat,
        Rabbit,
        Turtle,
        Puppy,
        Elephant,
        Snake
    }

    public AnimalType type;
    public int ID;
    public int point;
    public string Dialogue;


    private void Awake()
    {
        _originalPosition = transform.position;
        var removedName = this.name.Replace("(Clone)", "");
        _changeSprite = Resources.Load<Sprite>($"Animal/{removedName}");
    }

    void Update()
    {
        var mousePosition = GetMousePos();

        if (_clicked)
        {
            transform.position = mousePosition + new Vector2(0.5f, 0.5f);
        }
    }

    void OnMouseDown()
    {
        _clicked = !_clicked;
    }

    void OnMouseUp()
    {
        //_dragging = false;
        //var v2 = new Vector2(this.transform.position.x, this.transform.position.y);
        //Vector2Int v2i;
        //v2i = new Vector2Int((int)v2.x, (int)v2.y);
        //if (!_clicked && !_crashed && !HouseManager.CheckHouse(v2i))
        //{
        //    this.GetComponent<SpriteRenderer>().sprite = _changeSprite;
        //    HouseManager.AddHouse(v2i);
        //    Destroy(this.GetComponent<BoxCollider2D>());
        //}
        //else if (HouseManager.CheckHouse(v2i))
        //{
        //    transform.position = _originalPosition;
        //}
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
