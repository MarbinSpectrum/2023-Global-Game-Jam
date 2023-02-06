using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bomb : Item
{
    public int BoomDistance;
    public int BoomPower;
    public GameObject BombEffect;
    public SoundObj soundObj;
    public override void runItemEffect()
    {
        Mole player = GameManager.instance.player;
        TileManager tileManager = TileManager.instance;

        Vector2Int pos = player.pos;

        for (int x = -BoomDistance + pos.x; x <= BoomDistance + pos.x; x++)
        {
            for (int y = -BoomDistance + pos.y; y <= BoomDistance + pos.y; y++)
            {
                TileType tileType = tileManager.GetTile(x, y);
                int distance = Mathf.Abs(pos.x - x) + Mathf.Abs(pos.y - y);
                if (BoomDistance < distance)
                    continue;
                tileManager.DigBlock(x, y, BoomPower);
            }
        }

        GameObject effect = Instantiate(BombEffect);
        effect.transform.position = transform.position;
        soundObj.RunSE();
    }
}
