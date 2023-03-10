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
    /// : pPosList의 좌표데이터 타일을 생성한다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override IEnumerator runCreateTiles(List<Vector2Int> pPosList, TileType pTileType)
    {
        tileType = pTileType;

        //해당타일의 종류에 따라서 체력을 결정해준다.
        int life = 2;

        foreach (Vector2Int pos in pPosList)
        {
            //타일의 좌표에 체력값을 등록해준다.
            tileLifes[pos] = life;
        }


        tileList.Clear();
        foreach (Vector2Int pos in pPosList)
        {
            //타일목록에 등록해준다.
            tileList.Add(pos);
        }


        foreach (Vector2Int pos in tileList)
        {
            //메인블록과 가장자리 블록을 생성해준다.
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
            if (createNum % crateWaitCycle == 0)
            {
                yield return new WaitForSeconds(craeteWaitTime);
            }
            createNum++;
        }
    }

}
