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
                if(y < h*0.3f)
                    tileBase = tileSand;
                else if(y < h * 0.7f)
                    tileBase = tileDirt0;
                else
                    tileBase = tileDirt1;

                tilemap.SetTile(new Vector3Int(x, -y, 0), tileBase);
            }
        }
    }

    public bool IsTile(int x,int y)
    {
        return tilemap.GetTile(new Vector3Int(x, y, 0)) != null;
    }

    public void RemoveTile(int x,int y)
    {
        tilemap.SetTile(new Vector3Int(x, y, 0), null);
    }
}
