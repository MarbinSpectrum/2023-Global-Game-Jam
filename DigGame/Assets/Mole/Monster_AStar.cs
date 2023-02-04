using MyLib;
using System.Collections.Generic;
using UnityEngine;

public class Monster_AStar
{
    ////////////////////////////////////////////////////////////////////////////////
    /// : pFrom에서 pTo로 이동하는 경로를 구한다.
    ////////////////////////////////////////////////////////////////////////////////
    public static List<Vector2Int> AstartRoute(Vector2Int pFrom, Vector2Int pTo, int[,] pMoveCost)
    {
        //4방향
        int[,] offset = { { 0, 1 }, { 0, -1 }, { -1, 0 }, { 1, 0 } };
        int arrayW = pMoveCost.GetLength(0);
        int arrayH = pMoveCost.GetLength(1);
        bool[,] isClose = new bool[arrayW, arrayH];

        List<Vector2Int> route = null;
        Vector2Int[,] parent = new Vector2Int[arrayW, arrayH];

        PriorityQueue<Algorithm.AstarNode> pq = new PriorityQueue<Algorithm.AstarNode>(); //열린리스트
        pq.Push(new Algorithm.AstarNode(Mathf.Abs(pFrom.x - pTo.x) + Mathf.Abs(pFrom.y - pTo.y), 0, pFrom, pFrom));

        bool explore = false;

        while (pq.Count() > 0)
        {
            Algorithm.AstarNode node = pq.Pop();
            if (isClose[node.pos.x, node.pos.y])
                continue;

            isClose[node.pos.x, node.pos.y] = true;

            parent[node.pos.x, node.pos.y] = node.parents;

            if (node.pos.x == pTo.x && node.pos.y == pTo.y)
            {
                explore = true;
                break;
            }

            for (int i = 0; i < 4; i++)
            {
                int ax = node.pos.x + offset[i, 0];
                int ay = node.pos.y + offset[i, 1];
                if (ax < 0 || ay < 0 || ax >= arrayW || ay >= arrayH)
                    continue;

                if (isClose[ax, ay])
                    continue;

                float g = node.g + pMoveCost[ax, ay];
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
                ax = parent[bx, by].x;
                ay = parent[bx, by].y;
            }
        }

        return route;
    }
}