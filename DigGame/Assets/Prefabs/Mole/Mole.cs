using MyLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// : �δ��� �̵������� �����Ǿ��ִ�.
/// : Ŭ������ġ�� �̵��ϰų� ����Ű�� ���������� �̵��Ѵ�.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class Mole : MonoBehaviour
{
    private bool movePlayer;

    [SerializeField]
    private Vector2Int pos;
    [SerializeField]
    private float moveDuration;
    [SerializeField]
    private float digDuration;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

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

        animator.SetTrigger("Idle");
        spriteRenderer.flipX = false;
        spriteRenderer.flipY = false;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : pRoutes���� �δ����� �̵��Ѵ�.
    /// : ���߿� ����� �����ٸ� ����� �ı����ؼ� �����.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public IEnumerator runDigMole(List<Vector2Int> pRoutes)
    {
        CreateTileMap tileMap = CreateTileMap.instance;

        foreach (Vector2Int movePos in pRoutes)
        {
            bool isBlock = tileMap.IsBlock(movePos.x, movePos.y); //�ش���ġ�� ����� �ִ��� �˻��Ѵ�.
            bool dig = false;
            if(isBlock)
            {
                //�ش� ��ġ�� ����� �����Ѵ�. ����� �Ǵ�.
                tileMap.DigBlock(movePos.x, movePos.y);
                dig = true;
            }

            bool rCheck = tileMap.IsBlock(movePos.x, movePos.y); //�ٽ��ѹ� �ش���ġ�� ����� �ִ��� �˻��Ѵ�.

            Direction direction = Direction.Null;
            if(pos.x + 1 == movePos.x)
            {
                direction = Direction.Right;
            }
            else if (pos.x - 1 == movePos.x)
            {
                direction = Direction.Left;
            }
            else if (pos.y + 1 == movePos.y)
            {
                direction = Direction.Up;
            }
            else if (pos.y - 1 == movePos.y)
            {
                direction = Direction.Down;
            }

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

                switch(direction)
                {
                    case Direction.Up:
                        animator.SetTrigger("UpDown");
                        spriteRenderer.flipX = false;
                        spriteRenderer.flipY = false;
                        break;
                    case Direction.Down:
                        animator.SetTrigger("UpDown");
                        spriteRenderer.flipX = false;
                        spriteRenderer.flipY = true;
                        break;
                    case Direction.Left:
                        animator.SetTrigger("Side");
                        spriteRenderer.flipX = true;
                        spriteRenderer.flipY = false;
                        break;

                    case Direction.Right:
                        animator.SetTrigger("Side");
                        spriteRenderer.flipX = false;
                        spriteRenderer.flipY = false;
                        break;
                }

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : Start
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Start()
    {
        transform.position = new Vector3(pos.x, pos.y, 0);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : Update
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private void Update()
    {
        if(Input.GetMouseButton(0) && movePlayer == false)
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
