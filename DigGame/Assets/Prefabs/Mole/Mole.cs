using MyLib;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// : 두더지 이동로직이 구현되어있다.
/// : 클릭한위치로 이동하거나 방향키로 누른곳으로 이동한다.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class Mole : MonoBehaviour
{
    private bool movePlayer;
    private string nowAni = "Idle";
    private Direction nowDic = Direction.Null;

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
    /// : 두더지 이동로직 현재위치 pos에서 pTargetPos로 이동하는 경로를 구하고
    /// : 해당 방향으로 최적인 방법으로 땅을파서 이동한다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public IEnumerator runDigMole(Vector2Int pTargetPos)
    {
        //타겟 위치로 이동하는 최적의 경로를 구한다.
        List<Vector2Int> routes = Monster_AStar.AstartRoute(pos, pTargetPos, routeW, routeH);

        //구한 경로를 토대로 땅을 판면서 이동한다.
        yield return runDigMole(routes);

        //이동이 끝났다는것을 체크한다.
        movePlayer = false;      
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : pRoutes따라서 두더지가 이동한다.
    /// : 도중에 블록을 만난다면 블록을 파기위해서 멈춘다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public IEnumerator runDigMole(List<Vector2Int> pRoutes)
    {
        TileManager tileManager = TileManager.instance;

        foreach (Vector2Int movePos in pRoutes)
        {
            bool isBlock = tileManager.IsBlock(movePos.x, movePos.y); //해당위치에 블록이 있는지 검사한다.
            bool dig = false;
            if(isBlock)
            {
                //해당 위치에 블록이 존재한다. 블록을 판다.
                tileManager.DigBlock(movePos.x, movePos.y);
                dig = true;
            }

            bool rCheck = tileManager.IsBlock(movePos.x, movePos.y); //다시한번 해당위치에 블록이 있는지 검사한다.

            if (pos.y == 1 && pos.y + 1 == movePos.y)
            {
                //y==1인곳에서는 위로 못간다.
                yield break;
            }
            if (pos.y == 1 && pos.x == 5 && pos.x + 1 == movePos.x)
            {
                //x==5인곳에서는 오른쪽으로 못간다.
                yield break;
            }
            if (pos.y == 1 && pos.x == -5 && pos.x - 1 == movePos.x)
            {
                //x==-5인곳에서는 왼쪽으로 못간다.
                yield break;
            }

            //현재 좌표와 이동할 좌표를 이용해서 이동할 방향을 구한다.
            if (pos.x + 1 == movePos.x)
            {
                nowDic = Direction.Right;
            }
            else if (pos.x - 1 == movePos.x)
            {
                nowDic = Direction.Left;
            }
            else if (pos.y + 1 == movePos.y)
            {
                nowDic = Direction.Up;
            }
            else if (pos.y - 1 == movePos.y)
            {
                nowDic = Direction.Down;
            }

            if (rCheck)
            {
                //아직도 블록이 존재한다.
                //digDuration만큼 대기하고 
                yield return new WaitForSeconds(digDuration);

                //이동을 중지한다.
                yield break;
            }
            else
            {
                switch(nowDic)
                {
                    //방향에 따른 애니메이션을 적용한다.
                    case Direction.Up:
                        if (nowAni != "UpDown")
                        {
                            animator.SetTrigger("UpDown");
                        }
                        spriteRenderer.flipX = false;
                        spriteRenderer.flipY = false;
                        break;
                    case Direction.Down:
                        if (nowAni != "UpDown")
                        {
                            animator.SetTrigger("UpDown");
                        }
                        spriteRenderer.flipX = false;
                        spriteRenderer.flipY = true;
                        break;
                    case Direction.Left:
                        if (nowAni != "Side")
                        {
                            animator.SetTrigger("Side");
                        }
                        spriteRenderer.flipX = true;
                        spriteRenderer.flipY = false;
                        break;
                    case Direction.Right:
                        if (nowAni != "Side")
                        {
                            animator.SetTrigger("Side");
                        }
                        spriteRenderer.flipX = false;
                        spriteRenderer.flipY = false;
                        break;
                }

                //해당위치에 블록이 존재하지 않는다.
                //해당위치로 이동한다.
                yield return MyLib.Action2D.MoveTo(transform, new Vector3(movePos.x, movePos.y, 0), moveDuration);
                pos = movePos;

                if (dig)
                {
                    //블록을 캐는 행동을 진행했다.
                    //이동을 중지한다.
                    yield break;
                }
            }
        }

        yield break;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : 현재 애니메이션 이름을 등록한다.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void SetAniName(string pAniName)
    {
        nowAni = pAniName;
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
        //if(Input.GetMouseButton(0) && movePlayer == false)
        //{
        //    movePlayer = true;
        //    Vector3 mousePos = Input.mousePosition;
        //    mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //    StartCoroutine(runDigMole(new Vector2Int(Mathf.FloorToInt(mousePos.x), Mathf.FloorToInt(mousePos.y))));
        //}

        if (movePlayer == false)
        {
            int dicX = (int)Input.GetAxisRaw("Horizontal");
            int dicY = (int)Input.GetAxisRaw("Vertical");
            if (dicX != 0 || dicY != 0)
            {
                movePlayer = true;
                StartCoroutine(runDigMole(new Vector2Int(pos.x + dicX, pos.y + dicY)));
            }         
            else if (nowAni != "Idle" && nowDic != Direction.Down)
            {
                //아무것도 작동안하고 있는 상태이며
                //아래를 보고 있는 상태가 아니다.

                //기본 동작자세로 돌아간다.
                animator.SetTrigger("Idle");
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = false;
            }
        }
    }
}
