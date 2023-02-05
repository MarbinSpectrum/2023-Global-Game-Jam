using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{

    private Vector2Int _mousePosition;
    private Vector2 _originalPosition;
    private bool _crashed;

    public bool _clicked = true;
    public int ID;
    private List<Vector2Int> _vectorList = new();
    public int point;

    private void Awake()
    {
        _originalPosition = transform.position;
    }

    void Update()
    {
        var mousePosition = GetMousePos();
        _mousePosition = GetMousePos();

        if (_clicked)
        {
            transform.position = mousePosition + new Vector2(0.5f, 0);
        }
    }

    void OnMouseDown()
    {
        _clicked = !_clicked;
        CheckNullTile();
        if (!_clicked && _crashed)
        {
            transform.position = _originalPosition;
            _crashed = false;
            PoolManager.instance.nowAnimal = null;

            Destroy(gameObject);
        }
        else if (!_crashed && !_clicked)
        {
            HouseManager.AddHouse(_vectorList);
            GameManager.instance.AddScore(point);
            GameManager.instance.killCnt++;
            this.GetComponent<PolygonCollider2D>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;

            PoolManager.instance.nowAnimal = null;
        }
    }

    private void CheckNullTile()
    {
        TileManager tileManager = TileManager.instance;
        _vectorList = AnimalData.CheckAnimalNumber(_mousePosition, ID);

        foreach (Vector2Int movePos in _vectorList)
        {
            bool isBlock = tileManager.IsBlock(movePos.x, movePos.y);
            if (isBlock || HouseManager.CheckHouse(movePos))
            {
                _crashed = true;
                break;
            }
            _crashed = false;
        }
    }

    private void CheckHouse()
    {

    }

    Vector2Int GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2Int pos = new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y));
        return pos;
    }
}
