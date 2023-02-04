using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class ObstacleTileGroup : TileGroup
{

    [SerializeField]
    public List<TileBase> mainTile;

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
            for (int j = 0; j < 4; j++)
                tileLifes[new Vector2Int(pos.x + j / 2, pos.y - j % 2)] = life;
        }


        tileList.Clear();
        foreach (Vector2Int pos in pPosList)
        {
            //Ÿ�ϸ�Ͽ� ������ش�.
            for (int j = 0; j < 4; j++)
                tileList.Add(new Vector2Int(pos.x + j / 2, pos.y - j % 2));
        }


        foreach (Vector2Int pos in pPosList)
        {
            //���κ���� ��ġ
            for (int j = 0; j < 4; j++)
                tileBody.SetTile(pos.x + j % 2, pos.y - j / 2, mainTile[j]);

        }
    }
}
