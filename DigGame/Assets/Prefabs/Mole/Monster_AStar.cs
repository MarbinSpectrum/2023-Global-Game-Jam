using MyLib;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AStar
{
    ////////////////////////////////////////////////////////////////////////////////
    /// : pFrom에서 pTo로 이동하는 경로를 구한다.
    ////////////////////////////////////////////////////////////////////////////////
    public static List<Vector2Int> AstartRoute(Vector2Int pFrom, Vector2Int pTo, int pW, int pH)
    {
        CreateTileMap tileMap = CreateTileMap.instance;

        //4방향
        int[,] offset = { { 0, 1 }, { 0, -1 }, { -1, 0 }, { 1, 0 } };
        HashSet<Vector2Int> isClose = new HashSet<Vector2Int>();

        List<Vector2Int> route = null;
        Dictionary<Vector2Int, Vector2Int> parent = new Dictionary<Vector2Int, Vector2Int>();

        PriorityQueue<Algorithm.AstarNode> pq = new PriorityQueue<Algorithm.AstarNode>(); //열린리스트
        pq.Push(new Algorithm.AstarNode(Mathf.Abs(pFrom.x - pTo.x) + Mathf.Abs(pFrom.y - pTo.y), 0, pFrom, pFrom));

        bool explore = false;

        while (pq.Count() > 0)
        {
            Algorithm.AstarNode node = pq.Pop();
            if (isClose.Contains(node.pos))
                continue;

            isClose.Add(node.pos);

            parent[node.pos] = node.parents;

            if (node.pos.x == pTo.x && node.pos.y == pTo.y)
            {
                explore = true;
                break;
            }

            for (int i = 0; i < 4; i++)
            {
                int ax = node.pos.x + offset[i, 0];
                int ay = node.pos.y + offset[i, 1];
                if (ax < pFrom.x - pW || ay < pFrom.y - pH || ax >= pFrom.x + pW || ay >= pFrom.y + pH)
                    continue;

                if (isClose.Contains(new Vector2Int(ax,ay)))
                    continue;

                TileType tileType = tileMap.GetTile(ax, ay);

                int cost = 1;
                switch (tileType)
                {
                    case TileType.Sand:
                        cost = 2;
                        break;
                    case TileType.Ground:
                        cost = 4;
                        break;
                    case TileType.DarkGound:
                        cost = 8;
                        break;
                }

                float g = node.g + cost;
                float h = 10 * (Mathf.Abs(ax - pTo.x) + Mathf.Abs(ay - pTo.y));

                pq.Push(new Algorithm.AstarNode(g + h, g, new Vector2Int(ax, ay), node.pos)); //parent 추가
            }
        }

        if (explore)
        {
            route = new List<Vector2Int>();
            int ax = pTo.x;
            int ay = pTo.y;

            while (ax != pFrom.x || ay != pFrom.y)
            {
                route.Add(new Vector2Int(ax, ay));
                int bx = ax;
                int by = ay;
                ax = parent[new Vector2Int(bx, by)].x;
                ay = parent[new Vector2Int(bx, by)].y;
            }
            route.Reverse();
        }

        return route;
    }
}