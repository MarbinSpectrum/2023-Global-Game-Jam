using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalData : MonoBehaviour
{
    public static List<Vector2Int> CheckAnimalNumber(Vector2Int pos, int animalNumber)
    {
        List<Vector2Int> _vectorList = new List<Vector2Int>();
        List<Vector2Int> _changeList = new List<Vector2Int>();
        switch (animalNumber)
        {
            case 101:
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(0, -1));
                break;
            case 102:
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(-1, -1));
                break;
            case 103:
                _vectorList.Add(new Vector2Int(0, 1));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(0, -2));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(-1, -1));
                _vectorList.Add(new Vector2Int(-1, -2));
                _vectorList.Add(new Vector2Int(-2, 0));
                _vectorList.Add(new Vector2Int(-2, -1));
                break;
            case 201:
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(-1, -1));
                break;
            case 202:
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(0, -2));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(-1, -1));
                _vectorList.Add(new Vector2Int(-1, -2));
                break;
            case 203:
                _vectorList.Add(new Vector2Int(-2, 0));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(-2, -1));
                _vectorList.Add(new Vector2Int(-1, -1));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(1, -1));
                _vectorList.Add(new Vector2Int(-1, -2));
                _vectorList.Add(new Vector2Int(0, -2));
                _vectorList.Add(new Vector2Int(1, -2));
                break;
            case 301:
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(-1, -1));
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(1, -1));
                break;
            case 302:
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(-2, -1));
                _vectorList.Add(new Vector2Int(-1, -1));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(1, -1));
                _vectorList.Add(new Vector2Int(-2, -2));
                _vectorList.Add(new Vector2Int(-1, -2));
                _vectorList.Add(new Vector2Int(0, -2));
                _vectorList.Add(new Vector2Int(1, -2));
                break;
            case 404:
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(-2, -1));
                _vectorList.Add(new Vector2Int(-1, -1));
                break;              
            case 405:               
                _vectorList.Add(new Vector2Int(-2, 0));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(-3, -1));
                _vectorList.Add(new Vector2Int(-2, -1));
                _vectorList.Add(new Vector2Int(-1, -1));
                break;              
            case 501:               
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(0, -2));
                _vectorList.Add(new Vector2Int(0, -3));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(-1, -1));
                _vectorList.Add(new Vector2Int(-1, -2));
                _vectorList.Add(new Vector2Int(-1, -3));
                _vectorList.Add(new Vector2Int(-2, 0));
                _vectorList.Add(new Vector2Int(-2, -1));
                _vectorList.Add(new Vector2Int(-2, -2));
                _vectorList.Add(new Vector2Int(-2, -3));
                _vectorList.Add(new Vector2Int(-3, 0));
                _vectorList.Add(new Vector2Int(-3, -1));
                _vectorList.Add(new Vector2Int(-3, -2));
                _vectorList.Add(new Vector2Int(-3, -3));
                _vectorList.Add(new Vector2Int(-4, 0));
                _vectorList.Add(new Vector2Int(-4, -1));
                _vectorList.Add(new Vector2Int(-4, -2));
                _vectorList.Add(new Vector2Int(-4, -3));
                break;              
            case 601:               
                _vectorList.Add(new Vector2Int(-2, 0));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(-2, -1));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(1, -1));
                _vectorList.Add(new Vector2Int(-2, -2));
                _vectorList.Add(new Vector2Int(-1, -2));
                _vectorList.Add(new Vector2Int(1, -2));
                _vectorList.Add(new Vector2Int(-1, -3));
                break;              
            case 602:               
                _vectorList.Add(new Vector2Int(-3, 0));
                _vectorList.Add(new Vector2Int(-2, 0));
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(-3, -1));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(-3, -2));
                _vectorList.Add(new Vector2Int(0, -2));
                _vectorList.Add(new Vector2Int(-3, -2));
                _vectorList.Add(new Vector2Int(-2, -3));
                _vectorList.Add(new Vector2Int(-1, -3));
                _vectorList.Add(new Vector2Int(0, -3));
                break;              
            case 603:               
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(-2, 0));
                _vectorList.Add(new Vector2Int(-2, -1));
                _vectorList.Add(new Vector2Int(-2, -2));
                _vectorList.Add(new Vector2Int(-1, -2));
                _vectorList.Add(new Vector2Int(-1, -3));
                break;              
            case 604:               
                _vectorList.Add(new Vector2Int(-2, 0));
                _vectorList.Add(new Vector2Int(-1, 0));
                _vectorList.Add(new Vector2Int(0, 0));
                _vectorList.Add(new Vector2Int(-2, -1));
                _vectorList.Add(new Vector2Int(0, -1));
                _vectorList.Add(new Vector2Int(-2, -2));
                _vectorList.Add(new Vector2Int(0, -2));
                _vectorList.Add(new Vector2Int(-1, -3));
                _vectorList.Add(new Vector2Int(0, -3));
                break;
        }
        foreach (var _vector in _vectorList)
        {
            _changeList.Add(new Vector2Int(_vector.x + pos.x, _vector.y + pos.y));
        }
        return _changeList;
    }
}
