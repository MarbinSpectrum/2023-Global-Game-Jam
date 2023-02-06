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
    private string nowAni = "Idle";
    private Direction nowDic = Direction.Null;

    public Vector2Int pos;
    [SerializeField]
    private float moveDuration;
    [SerializeField]
    private float digDuration;

    [SerializeField]
    private SoundObj snowSE;
    [SerializeField]
    private SoundObj digSE;


    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    const int routeW = 7;
    const int routeH = 7;

    public GameManager GameManager;

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
    /// : ���߿� ������ �����ٸ� ������ �ı����ؼ� �����.
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public IEnumerator runDigMole(List<Vector2Int> pRoutes)
    {
        TileManager tileManager = TileManager.instance;
        ItemManager itemManager = ItemManager.instance;
        GameManager gameManager = GameManager.instance;

        foreach (Vector2Int movePos in pRoutes)
        {
            bool isBlock = tileManager.IsBlock(movePos.x, movePos.y); //�ش���ġ�� ������ �ִ��� �˻��Ѵ�.
            bool dig = false;
            if(isBlock)
            {
                //�ش� ��ġ�� ������ �����Ѵ�. ������ �Ǵ�.
                tileManager.DigBlock(movePos.x, movePos.y);
                dig = true;
            }

            bool rCheck = tileManager.IsBlock(movePos.x, movePos.y); //�ٽ��ѹ� �ش���ġ�� ������ �ִ��� �˻��Ѵ�.

            if(pos.y == 1 && pos.y + 1 == movePos.y)
            {
                yield break;
            }
            else if (pos.y == 1 && pos.x == 5 && pos.x + 1 == movePos.x)
            {
                yield break;
            }
            else if (pos.y == 1 && pos.x == -5 && pos.x - 1 == movePos.x)
            {
                yield break;
            }

            //���� ��ǥ�� �̵��� ��ǥ�� �̿��ؼ� �̵��� ������ ���Ѵ�.
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
                //������ ������ �����Ѵ�.
                //digDuration��ŭ ����ϰ� 

                float finalDigDuration = digDuration;
                if (gameManager.digUpTime > 0)
                    finalDigDuration /= gameManager.digUpRate;

                yield return new WaitForSeconds(finalDigDuration);

                //�̵��� �����Ѵ�.
                yield break;
            }
            else
            {
                switch(nowDic)
                {
                    //���⿡ ���� �ִϸ��̼��� �����Ѵ�.
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

                if (pos.y == 1)
                {
                    snowSE.RunSE();
                }
                else
                {
                    digSE.RunSE();
                }
                //�ش���ġ�� ������ �������� �ʴ´�.
                //�ش���ġ�� �̵��Ѵ�.

                float finalMoveDuration = moveDuration;
                if(gameManager.speedUpTime > 0)
                    finalMoveDuration /= gameManager.speedUpRate;
                yield return MyLib.Action2D.MoveTo(transform, new Vector3(movePos.x, movePos.y, 0), finalMoveDuration);

                pos = movePos;

                itemManager.SpawnItem(pos);

                Item item = itemManager.GetItem(pos);
                if(item != null)
                {
                    item.runItemEffect();
                    itemManager.RemoveItem(pos);
                }


                if (dig)
                {
                    //������ ĳ�� �ൿ�� �����ߴ�.
                    //�̵��� �����Ѵ�.
                    yield break;
                }
            }
        }

        yield break;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// : ���� �ִϸ��̼� �̸��� ����Ѵ�.
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
      
        if (movePlayer == false)
        {
            int dicX = (int)Input.GetAxisRaw("Horizontal");
            int dicY = (int)Input.GetAxisRaw("Vertical");
            if (dicX != 0 || dicY != 0)
            {
                if (GameManager.instance.isGameover)
                    return;
                if (GameManager.instance.timeStop)
                    return;

                movePlayer = true;
                StartCoroutine(runDigMole(new Vector2Int(pos.x + dicX, pos.y + dicY)));
            }         
            else if (nowAni != "Idle" && nowDic != Direction.Down)
            {
                animator.SetTrigger("Idle");
                spriteRenderer.flipX = false;
                spriteRenderer.flipY = false;
            }
        }
    }





   
}
