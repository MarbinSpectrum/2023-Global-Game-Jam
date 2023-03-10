using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// : 타일맵 생성 및 해당 타일의 정보를 가지고 있다.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class CreateTileMap : MonoBehaviour
{
    public const int HEIGHT = 50;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : 맵을 생성한다. 위치에 따른 타일종류와 체력을 지정해주고 타일을 생성해준다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Dictionary<TileType, List<Vector2Int>> CreateMap()
    {
        //타일 생성함수는 임시로 만들었다. 나중에 수정예정

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
        for(int y = -HEIGHT; y > -HEIGHT* 1.2f; y--)
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
