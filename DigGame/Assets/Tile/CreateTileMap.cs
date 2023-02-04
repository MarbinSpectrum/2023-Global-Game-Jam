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
    [SerializeField]
    private int h;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : ���� �����Ѵ�. ��ġ�� ���� Ÿ�������� ü���� �������ְ� Ÿ���� �������ش�.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Dictionary<TileType, List<Vector2Int>> CreateMap()
    {
        //Ÿ�� �����Լ��� �ӽ÷� �������. ���߿� ��������

        Dictionary<TileType, List<Vector2Int>> tileList = new Dictionary<TileType, List<Vector2Int>>();
        for(int y = 0; y > -h; y--)
        {
            for (int x = -5+y; x <= 5-y; x++)
            {
                TileType tileType = TileType.Null;
                if (y > -h / 2)
                    tileType = TileType.Sand;
                else
                    tileType = TileType.Ground;

                if (tileList.ContainsKey(tileType) == false)
                    tileList[tileType] = new List<Vector2Int>();
                tileList[tileType].Add(new Vector2Int(x, y));
            }
        }

        return tileList;
    }
}
