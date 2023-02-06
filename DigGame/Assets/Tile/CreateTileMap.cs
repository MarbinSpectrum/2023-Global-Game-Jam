using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// : Ÿ�ϸ� ���� �� �ش� Ÿ���� ������ ������ �ִ�.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class CreateTileMap : MonoBehaviour
{
    public const int HEIGHT = 50;

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
                    if (y > -HEIGHT * 0.3f)
                        tileType = TileType.Sand;
                    else if (y > -HEIGHT * 0.6f)
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
        for(int y = -HEIGHT; y > -HEIGHT* 2; y--)
        {
            for (int x = -5 - HEIGHT; x <= 5 + HEIGHT; x++)
            {

                TileType tileType = TileType.Gravel;
                if (tileList.ContainsKey(tileType) == false)
                    tileList[tileType] = new List<Vector2Int>();
                tileList[tileType].Add(new Vector2Int(x, y));
            }
        }

        return tileList;
    }
}
