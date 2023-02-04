using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager
{
    private static HashSet<Vector2Int> houseList = new HashSet<Vector2Int>();

    public static void AddHouse(Vector2Int housePos)
    {
        houseList.Add(housePos);
    }

    public static bool CheckHouse(Vector2Int animalPos)
    {
        return houseList.Contains(animalPos);
    }
}
