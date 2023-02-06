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
        int h = CreateTileMap.HEIGHT;
        for (int i = 0; i < 150; i++)
        {
            int r = Random.Range(0, (int)(h*0.3) * (10 + 2 * h));
            int x = r % (10 + 2 * h) - (5 + h);
            int y = -(r / (10 + 2 * h));
            CrateObstacle(x, y);
        }
        for (int i = 0; i < 100; i++)
        {
            int r = Random.Range((int)(h * 0.3) * (10 + 2 * h), (int)(h * 0.6) * (10 + 2 * h));
            int x = r % (10 + 2 * h) - (5 + h);
            int y = -(r / (10 + 2 * h));
            CrateObstacle(x, y);
        }
        for (int i = 0; i < 25; i++)
        {
            int r = Random.Range((int)(h * 0.6) * (10 + 2 * h), h * (10 + 2 * h));
            int x = r % (10 + 2 * h) - (5 + h);
            int y = -(r / (10 + 2 * h));
            CrateObstacle(x, y);
        }

        foreach (Vector2Int pos in tileList)
        {
            //타일의 좌표에 체력값을 등록해준다.
            tileLifes[pos] = life;
        }
    }   
    
    public void CrateObstacle(int x,int y)
    {
        TileManager tileManager = TileManager.instance;
        int r = Random.Range(0,3);
        switch(r)
        {
            case 0:
                {
                    if (tileList.Contains(new Vector2Int(x, y)) || 
                        tileList.Contains(new Vector2Int(x, y - 1)) ||
                        tileList.Contains(new Vector2Int(x + 1, y)) || 
                        tileList.Contains(new Vector2Int(x + 1, y - 1)))
                        return;
                    if (tileManager.GetTile(x, y) == TileType.Gravel ||
                        tileManager.GetTile(x, y - 1) == TileType.Gravel ||
                        tileManager.GetTile(x + 1, y) == TileType.Gravel ||
                        tileManager.GetTile(x + 1, y - 1) == TileType.Gravel)
                        return;

                    tileList.Add(new Vector2Int(x, y));
                    tileList.Add(new Vector2Int(x, y - 1));
                    tileList.Add(new Vector2Int(x + 1, y));
                    tileList.Add(new Vector2Int(x + 1, y - 1));
                    tileBody.SetTile(x, y, mainTile[0]);
                    tileBody.SetTile(x + 1, y, mainTile[2]);
                    tileBody.SetTile(x, y - 1, mainTile[6]);
                    tileBody.SetTile(x + 1, y - 1, mainTile[4]);
                }
                break;
            case 1:
                {
                    if (tileList.Contains(new Vector2Int(x, y)) ||
                        tileList.Contains(new Vector2Int(x, y - 1)) ||
                        tileList.Contains(new Vector2Int(x + 1, y)) ||
                        tileList.Contains(new Vector2Int(x + 1, y - 1)) ||
                         tileList.Contains(new Vector2Int(x + 2, y)) ||
                        tileList.Contains(new Vector2Int(x + 2, y - 1)
                        ))
                        return;
                    if (tileManager.GetTile(x, y) == TileType.Gravel ||
                        tileManager.GetTile(x, y - 1) == TileType.Gravel ||
                        tileManager.GetTile(x + 1, y) == TileType.Gravel ||
                        tileManager.GetTile(x + 1, y - 1) == TileType.Gravel ||
                        tileManager.GetTile(x + 2, y) == TileType.Gravel ||
                        tileManager.GetTile(x + 2, y - 1) == TileType.Gravel)
                        return;

                    tileList.Add(new Vector2Int(x, y));
                    tileList.Add(new Vector2Int(x, y - 1));
                    tileList.Add(new Vector2Int(x + 1, y));
                    tileList.Add(new Vector2Int(x + 1, y - 1));
                    tileList.Add(new Vector2Int(x + 2, y));
                    tileList.Add(new Vector2Int(x + 2, y - 1));
                    tileBody.SetTile(x, y, mainTile[0]);
                    tileBody.SetTile(x + 1, y, mainTile[1]);
                    tileBody.SetTile(x + 2, y, mainTile[2]);
                    tileBody.SetTile(x, y - 1, mainTile[6]);
                    tileBody.SetTile(x + 1, y - 1, mainTile[5]);
                    tileBody.SetTile(x + 2, y - 1, mainTile[4]);
                }
                break;
            case 2:
                {
                    if (tileList.Contains(new Vector2Int(x, y)) ||
                        tileList.Contains(new Vector2Int(x, y - 1)) ||
                        tileList.Contains(new Vector2Int(x, y - 2)) ||
                        tileList.Contains(new Vector2Int(x + 1, y)) ||
                        tileList.Contains(new Vector2Int(x + 1, y - 1)) ||
                        tileList.Contains(new Vector2Int(x + 1, y - 2)))
                        return;
                    if (tileManager.GetTile(x, y) == TileType.Gravel ||
                        tileManager.GetTile(x, y - 1) == TileType.Gravel ||
                        tileManager.GetTile(x, y - 2) == TileType.Gravel ||
                        tileManager.GetTile(x + 1, y ) == TileType.Gravel ||
                        tileManager.GetTile(x + 1, y - 1) == TileType.Gravel ||
                        tileManager.GetTile(x + 1, y - 2) == TileType.Gravel)
                        return;
                    tileList.Add(new Vector2Int(x, y));
                    tileList.Add(new Vector2Int(x, y - 1));
                    tileList.Add(new Vector2Int(x, y - 2));
                    tileList.Add(new Vector2Int(x + 1, y));
                    tileList.Add(new Vector2Int(x + 1, y - 1));
                    tileList.Add(new Vector2Int(x + 1, y - 2));
                    tileBody.SetTile(x, y, mainTile[0]);
                    tileBody.SetTile(x + 1, y, mainTile[2]);
                    tileBody.SetTile(x, y - 1, mainTile[7]);
                    tileBody.SetTile(x + 1, y - 1, mainTile[3]);
                    tileBody.SetTile(x, y - 2, mainTile[6]);
                    tileBody.SetTile(x + 1, y - 2, mainTile[4]);
                }
                break;

        }
    }
}
