using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGroup : MonoBehaviour
{
    protected TileType tileType;

    [SerializeField]
    protected TileBase bodyTile;
    [SerializeField]
    private List<TileBase> outline = new List<TileBase>();

    [SerializeField]
    protected TileBody tileBody;

    [SerializeField]
    private TileOutline tileOutline;

    protected HashSet<Vector2Int> tileList = new HashSet<Vector2Int>();
    protected Dictionary<Vector2Int, int> tileLifes = new Dictionary<Vector2Int, int>();              //위치, 타일체력

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : x,y 위치에 타일을 제거한다.
    /// : 그후 주변 타일의 이미지들을 갱신해준다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void RemoveTile(int x,int y)
    {
        tileBody.SetTile(x, y, null);
        tileList.Remove(new Vector2Int(x, y));

        for (int i = x * 2 - 1; i <= x * 2 + 2; i++)
        {
            for (int j = y * 2 - 1; j <= y * 2 + 2; j++)
            {
                tileOutline.SetTile(i, j, null);
            }
        }

        for(int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
                UpdateOutBlock(new Vector2Int(x + i, y + j));
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : x,y 위치의 가장자리 블록을 생성해준다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void UpdateOutBlock(Vector2Int pos)
    {
        Vector2Int newPos = new Vector2Int(pos.x * 2, pos.y * 2);
        if (tileList.Contains(pos) == false)
        {
            return;
        }

        Vector2Int uPos = new Vector2Int(pos.x, pos.y + 1);
        Vector2Int dPos = new Vector2Int(pos.x, pos.y - 1);
        Vector2Int lPos = new Vector2Int(pos.x - 1, pos.y);
        Vector2Int rPos = new Vector2Int(pos.x + 1, pos.y);
        Vector2Int ulPos = new Vector2Int(pos.x - 1, pos.y + 1);
        Vector2Int urPos = new Vector2Int(pos.x + 1, pos.y + 1);
        Vector2Int dlPos = new Vector2Int(pos.x - 1, pos.y - 1);
        Vector2Int drPos = new Vector2Int(pos.x + 1, pos.y - 1);

        {
            Vector2Int posA = new Vector2Int(newPos.x - 1, newPos.y + 2);

            if (tileList.Contains(ulPos) == false && tileList.Contains(lPos) == false && tileList.Contains(uPos) == false)
            {
                tileOutline.SetTile(posA.x, posA.y, outline[4]);
            }
        }

        {
            Vector2Int posB = new Vector2Int(newPos.x, newPos.y + 2);

            if (tileList.Contains(uPos) == false)
            {
                if (tileList.Contains(ulPos) == false)
                {
                    tileOutline.SetTile(posB.x, posB.y, outline[5]);
                }
                else
                {
                    tileOutline.SetTile(posB.x, posB.y, outline[2]);
                }
            }
        }

        {
            Vector2Int posC = new Vector2Int(newPos.x + 1, newPos.y + 2);

            if (tileList.Contains(uPos) == false)
            {
                if (tileList.Contains(urPos) == false)
                {
                    tileOutline.SetTile(posC.x, posC.y, outline[5]);
                }
                else
                {
                    tileOutline.SetTile(posC.x, posC.y, outline[3]);
                }
            }
        }

        {
            Vector2Int posD = new Vector2Int(newPos.x + 2, newPos.y + 2);

            if (tileList.Contains(urPos) == false && tileList.Contains(uPos) == false && tileList.Contains(rPos) == false)
            {
                tileOutline.SetTile(posD.x, posD.y, outline[6]);
            }
        }

        {
            Vector2Int posE = new Vector2Int(newPos.x + 2, newPos.y + 1);

            if (tileList.Contains(rPos) == false)
            {
                if (tileList.Contains(urPos) == false)
                {
                    tileOutline.SetTile(posE.x, posE.y, outline[7]);
                }
                else
                {
                    tileOutline.SetTile(posE.x, posE.y, outline[0]);
                }
            }
        }

        {
            Vector2Int posF = new Vector2Int(newPos.x + 2, newPos.y + 0);

            if (tileList.Contains(rPos) == false)
            {
                if (tileList.Contains(drPos) == false)
                {
                    tileOutline.SetTile(posF.x, posF.y, outline[7]);
                }
                else
                {
                    tileOutline.SetTile(posF.x, posF.y, outline[2]);
                }
            }
        }

        {
            Vector2Int posG = new Vector2Int(newPos.x + 2, newPos.y - 1);

            if (tileList.Contains(drPos) == false && tileList.Contains(rPos) == false && tileList.Contains(dPos) == false)
            {
                tileOutline.SetTile(posG.x, posG.y, outline[8]);
            }
        }

        {
            Vector2Int posH = new Vector2Int(newPos.x + 1, newPos.y - 1);

            if (tileList.Contains(dPos) == false)
            {
                if (tileList.Contains(drPos) == false)
                {
                    tileOutline.SetTile(posH.x, posH.y, outline[9]);
                }
                else
                {
                    tileOutline.SetTile(posH.x, posH.y, outline[1]);
                }
            }
        }

        {
            Vector2Int posI = new Vector2Int(newPos.x + 0, newPos.y - 1);

            if (tileList.Contains(dPos) == false)
            {
                if (tileList.Contains(dlPos) == false)
                {
                    tileOutline.SetTile(posI.x, posI.y, outline[9]);
                }
                else
                {
                    tileOutline.SetTile(posI.x, posI.y, outline[0]);
                }
            }
        }

        {
            Vector2Int posJ = new Vector2Int(newPos.x - 1, newPos.y - 1);

            if (tileList.Contains(dlPos) == false && tileList.Contains(dPos) == false && tileList.Contains(lPos) == false)
            {
                tileOutline.SetTile(posJ.x, posJ.y, outline[10]);
            }
        }

        {
            Vector2Int posK = new Vector2Int(newPos.x - 1, newPos.y + 0);

            if (tileList.Contains(lPos) == false)
            {
                if (tileList.Contains(dlPos) == false)
                {
                    tileOutline.SetTile(posK.x, posK.y, outline[11]);
                }
                else
                {
                    tileOutline.SetTile(posK.x, posK.y, outline[3]);
                }
            }
        }

        {
            Vector2Int posL = new Vector2Int(newPos.x - 1, newPos.y + 1);

            if (tileList.Contains(lPos) == false)
            {
                if (tileList.Contains(ulPos) == false)
                {
                    tileOutline.SetTile(posL.x, posL.y, outline[11]);
                }
                else
                {
                    tileOutline.SetTile(posL.x, posL.y, outline[1]);
                }
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : pos위치에 타일이 있는가를 반환한다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool IsTile(Vector2Int pos)
    {
        if (tileList.Contains(pos))
            return true;
        return false;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : pPosList의 좌표데이터 타일을 생성한다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public virtual void SetTile(List<Vector2Int> pPosList,TileType pTileType)
    {
        tileType = pTileType;

        //해당타일의 종류에 따라서 체력을 결정해준다.
        int life = 1;
        switch (tileType)
        {
            case TileType.Sand:
                life = 2;
                break;
            case TileType.Ground:
                life = 3;
                break;
            case TileType.DarkGound:
                life = 4;
                break;
            case TileType.Gravel:
                life = int.MaxValue;
                break;

        }

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
            tileBody.SetTile(pos.x, pos.y, bodyTile);
            UpdateOutBlock(pos);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : pos위치의 블록을 캔다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public virtual void DigTile(Vector2Int pos,int digValue = 1)
    {
        if (tileLifes.ContainsKey(pos) == false)
        {
            //해당위치에 키가 없다는 것은 블록도 없다는뜻
            //블록을 캐지않는다.
            return;
        }

        if (tileLifes[pos] > 0)
        {
            //블록의 체력이 존재한다.
            //블록을 파낸다.
            tileLifes[pos]-= digValue;
            if (tileLifes[pos] <= 0)
            {
                //블록의 체력이 0이 되었다.
                //해당 위치의 블록을 없애준다.
                RemoveTile(pos.x, pos.y);
            }
        }
    }
}
