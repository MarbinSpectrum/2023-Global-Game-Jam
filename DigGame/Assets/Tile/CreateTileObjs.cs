using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateTileObjs : FieldObjectSingleton<CreateTileObjs>
{
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

    private Dictionary<Vector2Int, TileType> tileDatas = new Dictionary<Vector2Int, TileType>();
    private Dictionary<Vector2Int, int> tileLifes = new Dictionary<Vector2Int, int>();

    private void Start()
    {
        CreateMap();
    }

    private void CreateMap()
    {
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
                    tileLifes[new Vector2Int(ax, ay)] = 1;
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

    public TileType GetTile(int x,int y)
    {
        if (tileDatas.ContainsKey(new Vector2Int(x, y)))
            return tileDatas[new Vector2Int(x, y)];
        return TileType.Null;
    }

    public bool IsBlock(int x,int y)
    {
        return tilemap.GetTile(new Vector3Int(x, y, 0)) != null;
    }

    public void DigTile(int x,int y)
    {
        Vector2Int pos = new Vector2Int(x, y);
        if (tileLifes.ContainsKey(pos) == false)
            return;

        if (tileLifes[pos] > 0)
            tileLifes[pos]--;

        if (tileLifes[pos] == 0)
        {
            tilemap.SetTile(new Vector3Int(x, y, 0), null);
            tileDatas[pos] = TileType.Null;
        }
    }
}
