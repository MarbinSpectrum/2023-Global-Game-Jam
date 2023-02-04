using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GravelTileGroup : TileGroup
{
    [SerializeField]
    protected TileBase snowTile;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : pPosList�� ��ǥ������ Ÿ���� �����Ѵ�.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override void SetTile(List<Vector2Int> pPosList, TileType pTileType)
    {
        tileType = pTileType;

        //�ش�Ÿ���� ������ ���� ü���� �������ش�.
        int life = int.MaxValue;

        foreach (Vector2Int pos in pPosList)
        {
            //Ÿ���� ��ǥ�� ü�°��� ������ش�.
            tileLifes[pos] = life;
        }


        tileList.Clear();
        foreach (Vector2Int pos in pPosList)
        {
            //Ÿ�ϸ�Ͽ� ������ش�.
            tileList.Add(pos);
        }


        foreach (Vector2Int pos in tileList)
        {
            //���κ��ϰ� �����ڸ� ������ �������ش�.
            if (pos.y == 0)
            {
                tileBody.SetTile(pos.x, pos.y, snowTile);
            }
            else
            {
                tileBody.SetTile(pos.x, pos.y, bodyTile);
            }
        }
    }
}