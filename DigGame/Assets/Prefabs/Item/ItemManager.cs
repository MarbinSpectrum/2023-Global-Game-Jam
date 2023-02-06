using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : DontDestroySingleton<ItemManager>
{
    private const int maxDistance = 11;
    private const int minDistance = 8;

    private Dictionary<Vector2Int, Item> hasItem = new Dictionary<Vector2Int, Item>();
    public Dictionary<ItemType, Item> itemObj = new Dictionary<ItemType, Item>();
    private int spawnCool = 0;

    public List<Vector2Int> ItemSpawnPos(Vector2Int pos)
    {
        TileManager tileManager = TileManager.instance;

        List<Vector2Int> spawnPosList = new List<Vector2Int>();

        for(int x = -pos.x- maxDistance; x <= pos.x + maxDistance; x++)
        {
            for (int y = pos.y - maxDistance; y <= pos.y+ maxDistance; y++)
            {
                if (y >= 0)
                    continue;
                TileType tileType = tileManager.GetTile(x, y);
                if (tileType == TileType.Obstacle)
                    continue;
                if (tileType == TileType.Gravel)
                    continue;
                int distance = Mathf.Abs(pos.x - x) + Mathf.Abs(pos.y - y);
                if (minDistance >= distance)
                    continue;
                if (hasItem.ContainsKey(new Vector2Int(x, y)))
                    continue;

                spawnPosList.Add(new Vector2Int(x, y));
            }
        }
        return spawnPosList;
    }

    public void SpawnItem(Vector2Int pMolePos)
    {
        //멀리있는 아이템 제거
        List<Vector2Int> removeList = new List<Vector2Int>();
        foreach (KeyValuePair<Vector2Int, Item> keyPair in hasItem)
        {
            Vector2Int pos = keyPair.Key;
            int distance = Mathf.Abs(pos.x - pMolePos.x) + Mathf.Abs(pos.y - pMolePos.y);
            if(distance > maxDistance*2)
            {
                removeList.Add(pos);
            }
        }
        foreach(Vector2Int pos in removeList)
        {
            RemoveItem(pos);
        }

        List<Vector2Int> ItemPosList = ItemSpawnPos(pMolePos); // 생성될 위치 후보
        List<ItemType> SpawnItemList = new List<ItemType>();   // 생성될 아이템 후보

        //없는 아이템을 찾아본다.
        foreach(ItemType item in System.Enum.GetValues(typeof(ItemType)))
        {
            if (item == ItemType.Null)
                continue;

            bool flag = false;
            foreach (KeyValuePair<Vector2Int, Item> keyPair in hasItem)
            {
                Item fieldItem = keyPair.Value;
                if(fieldItem.item == item)
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
                continue;

            SpawnItemList.Add(item);
        }

        if (ItemPosList.Count == 0 || SpawnItemList.Count == 0) //생성 가능한 위치가 없거나 //생성 가능한 아이템이 없다.
            return;

        if(spawnCool > 0)
        {
            spawnCool--;
            return;
        }

        int randomPosIdx = Random.Range(0, ItemPosList.Count);
        Vector2Int itemPos = ItemPosList[randomPosIdx];

        int randomItem = Random.Range(0, SpawnItemList.Count);
        ItemType itemType = SpawnItemList[randomItem];

        SpawnItem(itemPos, itemType);
        spawnCool = 20;
    }

    public void RemoveItem(Vector2Int pos)
    {
        if (hasItem.ContainsKey(pos) == false)
            return;
        Item itemObj = hasItem[pos];
        hasItem.Remove(pos);
        Destroy(itemObj.gameObject);
    }

    public void SpawnItem(Vector2Int pos,ItemType pItem)
    {
        Item item = itemObj[pItem];
        Item newItem = Instantiate(item, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
        hasItem.Add(pos, newItem);
    }

    public Item GetItem(Vector2Int pos)
    {
        if (hasItem.ContainsKey(pos) == false)
            return null;
        return hasItem[pos];
    }

}