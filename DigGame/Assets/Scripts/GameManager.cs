using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public PoolManager poolManager ;
    public static GameManager instance;

    public bool isGameover = false; // 게임 오버 상태
   

    [Header("Timer System")]
    //public Text[] text_time;
    public float curTime; //초
    public float maxMin; //분 // 일단 입력하게 해뒀는데 나중에 고정합쉬다 

    [Header("Score System")]
    public Text text_score;
    public int score;

    public Text DialogueText;



    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        curTime = maxMin * 60; // 나중에 시간 고정되면 수정 

    }


    void Update()
    {

        //TimeSystem();
        //ScoreSystem();
        DialogueSystem();
    }

    // 점수를 증가시키는 메서드
    public void AddScore(int newScore)
    {

    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void OnPlayerDead()
    {

    }

    public void TimeSystem()
    {

        if (!isGameover)
        {
            curTime -= Time.deltaTime;
           
            if ((int)curTime % 60 == 0 && (int)curTime / 60 % 60 == 0)
            {
                isGameover = true;
            }
        }
    }

    public void ScoreSystem()
    {
        text_score.text = score.ToString();
    }


    public void DialogueSystem()
    {
       DialogueText.text = poolManager.DialogueNow;
    }




}

