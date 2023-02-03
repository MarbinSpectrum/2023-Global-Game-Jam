using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    private Vector2Int pos;
    private bool movePlayer;
    [SerializeField]
    private float moveDuration;

    public IEnumerator runDigMole(Vector2Int pTargetPos)
    {
        if (pos == pTargetPos)
        {
            //해당위치에 도착했다.
            movePlayer = false;
            yield break;
        }

        Vector2Int movePos = pos;
        if (pos.x < pTargetPos.x)
            movePos.x += 1;
        else if (pos.x > pTargetPos.x)
            movePos.x -= 1;
        else if (pos.y < pTargetPos.y)
            movePos.y += 1;
        else if (pos.y > pTargetPos.y)
            movePos.y -= 1;

        bool isTile = CreateTileObjs.instance.IsTile(movePos.x, movePos.y);
        if(isTile)
            CreateTileObjs.instance.RemoveTile(movePos.x, movePos.y);
        yield return MyLib.Action2D.MoveTo(transform, new Vector3(movePos.x, movePos.y, 0), moveDuration);
        pos = movePos;

        if (isTile == false)
            StartCoroutine(runDigMole(pTargetPos));
        else
            movePlayer = false;
    }

    public void Update()
    {

        if(Input.GetMouseButtonDown(0) && movePlayer == false)
        {
            movePlayer = true;
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(mousePos);
            StartCoroutine(runDigMole(new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y))));

        }
    }
}
