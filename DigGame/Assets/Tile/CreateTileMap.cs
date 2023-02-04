using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// : 타일맵 생성 및 해당 타일의 정보를 가지고 있다.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class CreateTileMap : FieldObjectSingleton<CreateTileMap>
{
    //임시 객체
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private TileBase tileSand;
    [SerializeField]
    private TileBase tileDirt0;
    [SerializeField]
    private TileBase tileDirt1;
    [SerializeField]
    private int h;

    private Dictionary<Vector2Int, TileType> tileDatas = new Dictionary<Vector2Int, TileType>();    //위치,타일종류
    private Dictionary<Vector2Int, int> tileLifes = new Dictionary<Vector2Int, int>();              //위치, 타일체력

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : Start
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Start()
    {
        CreateMap();
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : 맵을 생성한다. 위치에 따른 타일종류와 체력을 지정해주고 타일을 생성해준다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void CreateMap()
    {
        //타일 생성함수는 임시로 만들었다. 나중에 수정예정
        for(int y = 0; y <= h; y++)
        {
            int w = 5 + y;
            for(int x = -w; x <= w; x++)
            {
                TileBase tileBase = tileSand;
                int ax = x;
                int ay = -y;
                if(y < h*0.3f)
                {
                    tileBase = tileSand;
                    tileDatas[new Vector2Int(ax, ay)] = TileType.Sand;
                    tileLifes[new Vector2Int(ax, ay)] = 2;
                }
                else if(y < h * 0.7f)
                {
                    tileBase = tileDirt0;
                    tileDatas[new Vector2Int(ax, ay)] = TileType.Ground;
                    tileLifes[new Vector2Int(ax, ay)] = 4;
                }
                else
                {
                    tileBase = tileDirt1;
                    tileDatas[new Vector2Int(ax, ay)] = TileType.DarkGound;
                    tileLifes[new Vector2Int(ax, ay)] = 16;
                }

                tilemap.SetTile(new Vector3Int(ax, ay, 0), tileBase);
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : x,y에 해당하는 TileType을 받아온다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public TileType GetTile(int x,int y)
    {
        if (tileDatas.ContainsKey(new Vector2Int(x, y)))
            return tileDatas[new Vector2Int(x, y)];
        return TileType.Null;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : x,y에 블록이 있는지 검사한다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool IsBlock(int x,int y)
    {
        TileBase tilebase = tilemap.GetTile(new Vector3Int(x, y, 0));

        if(tilebase == null)
        {
            //해당 위치에 타일이 없다면 블록이 없는것이다.
            return false;
        }

        //나머지의 경우는 타일이 있다고 가정한다.
        return true;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : x,y의 블록을 판다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void DigBlock(int x,int y)
    {
        Vector2Int pos = new Vector2Int(x, y);
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
            tileLifes[pos]--;
            if (tileLifes[pos] == 0)
            {
                //블록의 체력이 0이 되었다.
                //해당 위치의 블록을 없애준다.
                tilemap.SetTile(new Vector3Int(x, y, 0), null);
                tileDatas[pos] = TileType.Null;
            }
        }

    }
}
