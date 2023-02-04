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
    /// : x,y�� �ش��ϴ� TileType�� �޾ƿ´�.
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
    /// : x,y�� ����� �ִ��� �˻��Ѵ�.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool IsBlock(int x, int y)
    {
        TileType tileType = GetTile(x,y);

        if (tileType == TileType.Null)
        {
            //�ش� ��ġ�� Ÿ���� ���ٸ� ����� ���°��̴�.
            return false;
        }

        //�������� ���� Ÿ���� �ִٰ� �����Ѵ�.
        return true;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : x,y�� ����� �Ǵ�.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void DigBlock(int x, int y)
    {
        Vector2Int pos = new Vector2Int(x, y);
        TileType tileType = GetTile(x, y);
        tileGroups[tileType].RemoveTile(pos.x, pos.y);
    }
}
