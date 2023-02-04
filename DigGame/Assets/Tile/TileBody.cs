using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileBody : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    public void SetTile(int x, int y, TileBase pTileBase)
    {
        tilemap.SetTile(new Vector3Int(x, y, 0), pTileBase);
    }
}
