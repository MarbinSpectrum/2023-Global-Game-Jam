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

        HashSet<Vector2Int> obstaclePos = new HashSet<Vector2Int>();
        List<Vector2Int> obstacleList = new List<Vector2Int>();

        for(int i = 0; i < 300; i++)
        {
            int r = Random.Range(0, 30 * (10 + 2 * h));
            int x = r % (10 + 2 * h) - (5 + h);
            int y = -(r / (10 + 2 * h));
            if (obstaclePos.Contains(new Vector2Int(x, y)) || obstaclePos.Contains(new Vector2Int(x, y - 1)) ||
                obstaclePos.Contains(new Vector2Int(x + 1, y)) || obstaclePos.Contains(new Vector2Int(x + 1, y - 1)))
                continue;
            obstacleList.Add(new Vector2Int(x, y));
            for (int j = 0; j < 4; j++)
                obstaclePos.Add(new Vector2Int(x + j / 2, y - j % 2));
        }
        for (int i = 0; i < 200; i++)
        {
            int r = Random.Range(30 * (10 + 2 * h), 60 * (10 + 2 * h));
            int x = r % (10 + 2 * h) - (5 + h);
            int y = -(r / (10 + 2 * h));
            if (obstaclePos.Contains(new Vector2Int(x, y)) || obstaclePos.Contains(new Vector2Int(x, y - 1)) ||
                obstaclePos.Contains(new Vector2Int(x + 1, y)) || obstaclePos.Contains(new Vector2Int(x + 1, y - 1)))
                continue;
            obstacleList.Add(new Vector2Int(x, y));
            for (int j = 0; j < 4; j++)
                obstaclePos.Add(new Vector2Int(x + j / 2, y - j % 2));
        }
        for (int i = 0; i < 50; i++)
        {
            int r = Random.Range(60 * (10 + 2 * h), h * (10 + 2 * h));
            int x = r % (10 + 2 * h) - (5 + h);
            int y = -(r / (10 + 2 * h));
            if (obstaclePos.Contains(new Vector2Int(x, y)) || obstaclePos.Contains(new Vector2Int(x, y - 1)) ||
                obstaclePos.Contains(new Vector2Int(x + 1, y)) || obstaclePos.Contains(new Vector2Int(x + 1, y - 1)))
                continue;
            obstacleList.Add(new Vector2Int(x, y));
            for (int j = 0; j < 4; j++)
                obstaclePos.Add(new Vector2Int(x + j / 2, y - j % 2));
        }

        for (int y = 0; y > -h; y--)
        {
            for (int x = -5 - h; x <= 5 + h; x++)
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

        tileList[TileType.Obstacle] = obstacleList;

        return tileList;
    }
}
