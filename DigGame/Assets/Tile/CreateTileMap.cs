using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// : Ÿ�ϸ� ���� �� �ش� Ÿ���� ������ ������ �ִ�.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class CreateTileMap : MonoBehaviour
{ 
    public const int HEIGHT = 100;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : ���� �����Ѵ�. ��ġ�� ���� Ÿ�������� ü���� �������ְ� Ÿ���� �������ش�.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Dictionary<TileType, List<Vector2Int>> CreateMap()
    {
        //Ÿ�� �����Լ��� �ӽ÷� �������. ���߿� ��������

        Dictionary<TileType, List<Vector2Int>> tileList = new Dictionary<TileType, List<Vector2Int>>();

        for (int y = 0; y > -HEIGHT; y--)
        {
            for (int x = -5 - HEIGHT; x <= 5 + HEIGHT; x++)
            {
                TileType tileType = TileType.Null;

                if (-5 + y / 2 <= x && x <= 5 - y / 2)
                {
                    if (y > -30)
                        tileType = TileType.Sand;
                    else if (y > -60)
                        tileType = TileType.Ground;
                    else
                        tileType = TileType.DarkGound;
                }
                else
                    tileType = TileType.Gravel;


                if (tileType != TileType.Null)
                {
                    if (tileList.ContainsKey(tileType) == false)
                        tileList[tileType] = new List<Vector2Int>();
                    tileList[tileType].Add(new Vector2Int(x, y));
                }
            }
        }
        tileList[TileType.Obstacle] = new List<Vector2Int>();

        return tileList;
    }
}
