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
    /// : pPosList의 좌표데이터 타일을 생성한다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public override void SetTile(List<Vector2Int> pPosList, TileType pTileType)
    {
        tileType = pTileType;

        //해당타일의 종류에 따라서 체력을 결정해준다.
        int life = int.MaxValue;

        foreach (Vector2Int pos in pPosList)
        {
            //타일의 좌표에 체력값을 등록해준다.
            for (int j = 0; j < 4; j++)
                tileLifes[new Vector2Int(pos.x + j / 2, pos.y - j % 2)] = life;
        }


        tileList.Clear();
        foreach (Vector2Int pos in pPosList)
        {
            //타일목록에 등록해준다.
            for (int j = 0; j < 4; j++)
                tileList.Add(new Vector2Int(pos.x + j / 2, pos.y - j % 2));
        }


        foreach (Vector2Int pos in pPosList)
        {
            //메인블록을 배치
            for (int j = 0; j < 4; j++)
                tileBody.SetTile(pos.x + j % 2, pos.y - j / 2, mainTile[j]);

        }
    }
}
