using MyLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MyLib.Algorithm;

public class Mole : MonoBehaviour
{
    private Vector2Int pos;
    private bool movePlayer;

    [SerializeField]
    private float moveDuration;
    [SerializeField]
    private float digDuration;

    const int routeW = 7;
    const int routeH = 7;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : �δ��� �̵����� ������ġ pos���� pTargetPos�� �̵��ϴ� ��θ� ���ϰ�
    /// : �ش� �������� ������ ������� �����ļ� �̵��Ѵ�.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public IEnumerator runDigMole(Vector2Int pTargetPos)
    {
        //Ÿ�� ��ġ�� �̵��ϴ� ������ ��θ� ���Ѵ�.
        List<Vector2Int> routes = Monster_AStar.AstartRoute(pos, pTargetPos, routeW, routeH);

        //���� ��θ� ���� ���� �Ǹ鼭 �̵��Ѵ�.
        yield return runDigMole(routes);

        //�̵��� �����ٴ°��� üũ�Ѵ�.
        movePlayer = false;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : pRoutes���� �δ����� �̵��Ѵ�.
    /// : ���߿� ����� �����ٸ� ����� �ı����ؼ� �����.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public IEnumerator runDigMole(List<Vector2Int> pRoutes)
    {
        foreach (Vector2Int movePos in pRoutes)
        {
            bool isBlock = CreateTileObjs.instance.IsBlock(movePos.x, movePos.y); //�ش���ġ�� ����� �ִ��� �˻��Ѵ�.
            bool dig = false;
            if(isBlock)
            {
                //�ش� ��ġ�� ����� �����Ѵ�. ����� �Ǵ�.
                CreateTileObjs.instance.DigTile(movePos.x, movePos.y);
                dig = true;
            }

            bool rCheck = CreateTileObjs.instance.IsBlock(movePos.x, movePos.y); //�ٽ��ѹ� �ش���ġ�� ����� �ִ��� �˻��Ѵ�.

            if (rCheck)
            {
                //������ ����� �����Ѵ�.
                //digDuration��ŭ ����ϰ� 
                yield return new WaitForSeconds(digDuration);

                //�̵��� �����Ѵ�.
                yield break;
            }
            else
            {
                //�ش���ġ�� ����� �������� �ʴ´�.
                //�ش���ġ�� �̵��Ѵ�.
                yield return MyLib.Action2D.MoveTo(transform, new Vector3(movePos.x, movePos.y, 0), moveDuration);
                pos = movePos;

                if (dig)
                {
                    //����� ĳ�� �ൿ�� �����ߴ�.
                    //�̵��� �����Ѵ�.
                    yield break;
                }

            }
        }

        yield break;
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0) && movePlayer == false)
        {
            movePlayer = true;
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            StartCoroutine(runDigMole(new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y))));
        }

        if (movePlayer == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movePlayer = true;
                StartCoroutine(runDigMole(new Vector2Int(pos.x, pos.y + 1)));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                movePlayer = true;
                StartCoroutine(runDigMole(new Vector2Int(pos.x, pos.y - 1)));
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                movePlayer = true;
                StartCoroutine(runDigMole(new Vector2Int(pos.x - 1, pos.y)));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                movePlayer = true;
                StartCoroutine(runDigMole(new Vector2Int(pos.x + 1, pos.y)));
            }
        }
    }
}
