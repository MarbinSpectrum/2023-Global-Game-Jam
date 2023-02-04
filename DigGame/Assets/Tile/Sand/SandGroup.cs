using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SandGroup : TileGroup
{
    [SerializeField]
    private TileBase snowTile;

    [SerializeField]
    private List<TileBase> biomeList = new List<TileBase>();

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : pPosList�� ��ǥ������ Ÿ���� �����Ѵ�.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override void SetTile(List<Vector2Int> pPosList, TileType pTileType)
    {
        tileType = pTileType;

        //�ش�Ÿ���� ������ ���� ü���� �������ش�.
        int life = 2;

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
            //���κ�ϰ� �����ڸ� ����� �������ش�.
            if(pos.y == 0)
            {
                tileBody.SetTile(pos.x, pos.y, snowTile);
            }
            else
            {
                int random = Random.Range(0, 100);
                if (random < 90)
                    tileBody.SetTile(pos.x, pos.y, bodyTile);
                else
                {
                    int r = Random.Range(0, biomeList.Count);
                    TileBase tileB = biomeList[r];
                    tileBody.SetTile(pos.x, pos.y, tileB);
                }

            }
            UpdateOutBlock(pos);
        }
    }

}
