using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : DontDestroySingleton<GameManager>
{
    public PoolManager poolManager;
    public Mole player;

    public bool isGameover = false; // 게임 오버 상태
    public Ending endObj;

    [Header("Timer System")]
    public int startTime;
    public int curTime;

    public bool timeStop = false;

    [Header("Score System")]
    public int score;
    public int killCnt;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI headerScoreText;
    public TextMeshProUGUI passBtnText;

    [Header("Item System")]
    public int speedUpTime = 0;
    public int digUpTime = 0;
    public float speedUpRate;
    public float digUpRate;
    public bool getFood;

    private void Start()
    {
        curTime = startTime;
    }

    public void GameStart()
    {
        timeStop = false;
        curTime = startTime;
        PoolManager.instance.AnimalSetting();
        StartCoroutine(runTimeLogic());
    }

    private IEnumerator runTimeLogic()
    {
        if(curTime > 0)
        {
            //시간이 멈춰있다.
            curTime--;
            speedUpTime--;
            digUpTime--;

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
        headerScoreText.text = LanguageManager.GetText("NOW_SCORE");
        passBtnText.text = LanguageManager.GetText("PASS_BTN");

        DialogueSystem();
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int addValue)
    {
        if (getFood)
        {
            score += addValue * 2;
            getFood = false;
        }
        else
        {
            score += addValue;
        }
    }

    // 점수를 증가시키는 메서드
    public void AddTime(int addValue)
    {
        int time = curTime;
        time += addValue;
        if (time >= startTime)
            time = startTime;
        curTime = time;
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

