using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : DontDestroySingleton<GameManager>
{
    public PoolManager poolManager;

    public bool isGameover = false; // 게임 오버 상태
    public Ending endObj;

    [Header("Timer System")]
    public int startTime;
    public int curTime;
    public bool timeStop = false;

    [Header("Score System")]
    public int score;
    public int killCnt;
    public Text DialogueText;

    private void Start()
    {
        curTime = startTime;
        StartCoroutine(runTimeLogic());
    }

    private IEnumerator runTimeLogic()
    {
        if(curTime > 0)
        {
            //시간이 멈춰있다.
            curTime--;

            yield return new WaitForSeconds(1);

            yield return new WaitWhile(() => timeStop);

            StartCoroutine(runTimeLogic());
        }
        else
        {
            GameOver();
            yield break;
        }
    }

    private void Update()
    {
        DialogueSystem();
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int addValue)
    {
        score += addValue;
    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void GameOver()
    {
        isGameover = true;
        endObj.StartEnding();
    }

    public void DialogueSystem()
    {
        DialogueText.text = poolManager.DialogueNow;
    }
}

