using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public static HashSet<Vector2Int> houseList = new();
    public static void AddHouse(List<Vector2Int> housePos)
    {
        foreach(var pos in housePos)
        {
            houseList.Add(pos);
        }
    }

    public static bool CheckHouse(Vector2Int housePos)
    {
        return houseList.Contains(housePos);
    }
}
