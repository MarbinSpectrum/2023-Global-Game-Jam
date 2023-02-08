using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private SpriteRenderer houseObj;
    [SerializeField]
    private SpriteRenderer gridObj;

    public int ID;
    public int point;

    public bool _clicked = true;
    private bool _crashed;

    private void Update()
    {
        if (_clicked)
        {
            Vector2Int mousePos = GetMousePos();
            transform.position = mousePos + new Vector2(0.5f, 0);
            if(Input.GetMouseButtonDown(0))
            {
                _clicked = !_clicked;

                List<Vector2Int> vectorList = AnimalData.CheckAnimalNumber(mousePos, ID);
                bool crashed = CheckCrash(vectorList);
                if (crashed)
                {
                    PoolManager.instance.DestroyNowAnimal();
                }
                else
                {
                    HouseManager.AddHouse(vectorList);
                    GameManager.instance.AddScore(point);
                    GameManager.instance.killCnt++;

                    spriteRenderer.enabled = false;
                    houseObj.enabled = true;
                    gridObj.enabled = false;

                    PoolManager.instance.nowAnimal = null;
                    PoolManager.instance.AnimalSetting();
                }
            }
        }
    }

    private bool CheckCrash(List<Vector2Int> pVectorList)
    {
        TileManager tileManager = TileManager.instance;

        foreach (Vector2Int checkPos in pVectorList)
        {
            bool isBlock = tileManager.IsBlock(checkPos.x, checkPos.y);
            if (isBlock || HouseManager.CheckHouse(checkPos) || checkPos.y > 0)
                return true;
        }
        return false;
    }

    public static Vector2Int GetMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2Int pos = new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y));
        return pos;
    }
}
