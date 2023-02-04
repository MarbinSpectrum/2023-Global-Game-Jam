using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileManager : FieldObjectSingleton<TileManager>
{
    [SerializeField]
    private CreateTileMap createTileMap;
    [SerializeField]
    private Dictionary<TileType, TileGroup> tileGroups = new Dictionary<TileType, TileGroup>();

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : Start
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Start()
    {
        Dictionary<TileType, List<Vector2Int>>  tileList = createTileMap.CreateMap();

        foreach (KeyValuePair<TileType, List<Vector2Int>> tileListPair in tileList)
        {
            TileType tileType = tileListPair.Key;
            List<Vector2Int> posList = tileListPair.Value;
            tileGroups[tileType].SetTile(posList, tileType);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : x,y에 해당하는 TileType을 받아온다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public TileType GetTile(int x, int y)
    {
        foreach (KeyValuePair<TileType, TileGroup> tileGroupPair in tileGroups)
        {
            if (tileGroupPair.Value.IsTile(new Vector2Int(x, y)))
                return tileGroupPair.Key;
        }
        return TileType.Null;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : x,y에 블록이 있는지 검사한다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool IsBlock(int x, int y)
    {
        TileType tileType = GetTile(x,y);

        if (tileType == TileType.Null)
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
    public void DigBlock(int x, int y)
    {
        Vector2Int pos = new Vector2Int(x, y);
        TileType tileType = GetTile(x, y);
        tileGroups[tileType].RemoveTile(pos.x, pos.y);
    }
}
